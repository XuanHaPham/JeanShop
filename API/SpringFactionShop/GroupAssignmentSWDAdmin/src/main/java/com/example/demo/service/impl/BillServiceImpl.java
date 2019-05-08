package com.example.demo.service.impl;

import com.example.demo.persistent.entity.Bill;
import com.example.demo.persistent.entity.BillDetail;
import com.example.demo.persistent.repository.AccountRepository;
import com.example.demo.persistent.repository.BillDetailRepository;
import com.example.demo.persistent.repository.BillRepository;
import com.example.demo.persistent.repository.ProductRepository;
import com.example.demo.service.BillService;
import com.example.demo.service.dto.BillDTO;
import com.example.demo.service.dto.BillDetailDTO;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import javax.persistence.EntityNotFoundException;
import javax.transaction.Transactional;
import java.nio.channels.FileLock;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Optional;

@Service
@Transactional
public class BillServiceImpl implements BillService {
     private final BillRepository billRepository;
     private final BillDetailRepository billDetailRepository;
     private final ProductRepository productRepository;
     private final AccountRepository accountRepository;

    public BillServiceImpl(BillRepository billRepository, BillDetailRepository billDetailRepository, ProductRepository productRepository, AccountRepository accountRepository) {
        this.billRepository = billRepository;
        this.billDetailRepository = billDetailRepository;
        this.productRepository = productRepository;
        this.accountRepository = accountRepository;
    }

    @Override
    public Boolean create(List<BillDetailDTO> billDetailDTOS, Integer accountID){
        float total = 0;
        for (BillDetailDTO b : billDetailDTOS) {
            float sum = productRepository.findByID(b.getProductID()).getPrice()*b.getBuyquantity();
            total += sum;
        }
        Bill bill = new Bill();
        bill.setTimeCreated(new Date());
        bill.setTotal(total);
        bill.setStatus(false);
        bill.setAccountID(accountID);
        billRepository.save(bill);
        for (BillDetailDTO b : billDetailDTOS) {
            int newQuantiTY = productRepository.findByID(b.getProductID()).getQuantity() - b.getBuyquantity();
            productRepository.updateQuantity(newQuantiTY, b.getProductID());
            BillDetail billDetail = new BillDetail();
            billDetail.setStatus(true);
            billDetail.setQuantity(b.getBuyquantity());
            billDetail.setProductID(b.getProductID());
            billDetail.setBillID(bill.getId());
            billDetailRepository.save(billDetail);
        }
        return true;
    }

    @Override
    public List<BillDTO> getAllBill(){
        List<Bill> bills = billRepository.findAllByIsDelete();
        List<BillDTO> billDTOS = new ArrayList<>();
        ModelMapper modelMapper = new ModelMapper();
        for (Bill b : bills ) {
            BillDTO billDTO = modelMapper.map(b, BillDTO.class);
            billDTO.setCustomerEmail(accountRepository.getEmailByID(b.getAccountID()));
                    billDTOS.add(billDTO);
        }
        return billDTOS;
    }
    @Override
    public List<BillDetailDTO> getAllProductOfBill(Integer billID){
        List<BillDetail> billDetails = billDetailRepository.findAllByIsDelete(billID);
        List<BillDetailDTO> billDetailDTOS = new ArrayList<>();
        ModelMapper modelMapper = new ModelMapper();
        for (BillDetail b : billDetails ) {
            billDetailDTOS.add(modelMapper.map(b, BillDetailDTO.class));
        }
        return billDetailDTOS;
    }

    @Override
    public Boolean updateStatus(Integer id){
        Optional.ofNullable(billRepository.findById(id)).orElseThrow(() ->new EntityNotFoundException());
        if(billRepository.findBillByID(id).getStatus())
        billRepository.deleteByID(id, false);
        else
            billRepository.deleteByID(id, true);
        return true;
    }
}
