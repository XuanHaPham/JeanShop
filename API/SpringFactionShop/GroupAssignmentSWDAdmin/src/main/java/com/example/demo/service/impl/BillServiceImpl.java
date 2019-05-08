package com.example.demo.service.impl;

import com.example.demo.persistent.entity.Bill;
import com.example.demo.persistent.entity.BillDetail;
import com.example.demo.persistent.repository.BillDetailRepository;
import com.example.demo.persistent.repository.BillRepository;
import com.example.demo.persistent.repository.ProductRepository;
import com.example.demo.service.BillService;
import com.example.demo.service.dto.BillDetailDTO;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.nio.channels.FileLock;
import java.util.Date;
import java.util.List;

@Service
@Transactional
public class BillServiceImpl implements BillService {
     private final BillRepository billRepository;
     private final BillDetailRepository billDetailRepository;
     private final ProductRepository productRepository;

    public BillServiceImpl(BillRepository billRepository, BillDetailRepository billDetailRepository, ProductRepository productRepository) {
        this.billRepository = billRepository;
        this.billDetailRepository = billDetailRepository;
        this.productRepository = productRepository;
    }

    @Override
    public Boolean create(List<BillDetailDTO> billDetailDTOS, Integer accountID){
        float total = 0;
        for (BillDetailDTO b : billDetailDTOS) {
            float sum = productRepository.findByID(b.getProductID()).getPrice()*b.getQuantity();
            total += sum;
        }
        Bill bill = new Bill();
        bill.setTimeCreated(new Date());
        bill.setTotal(total);
        bill.setStatus(false);
        bill.setAccountID(accountID);
        billRepository.save(bill);
        for (BillDetailDTO b : billDetailDTOS) {
            int newQuantiTY = productRepository.findByID(b.getProductID()).getQuantity() - b.getQuantity();
            productRepository.updateQuantity(newQuantiTY, b.getProductID());
            BillDetail billDetail = new BillDetail();
            billDetail.setStatus(true);
            billDetail.setQuantity(b.getQuantity());
            billDetail.setProductID(b.getProductID());
            billDetail.setBillID(bill.getId());
            billDetailRepository.save(billDetail);
            System.out.println("AAAAAAAAAAAAAAAAAAAAAA"+ billDetail.getBillID());
        }
        return true;
    }
}
