package com.example.demo.service.impl;

import com.example.demo.persistent.entity.Product;
import com.example.demo.persistent.repository.ProductRepository;
import com.example.demo.service.ProductService;
import com.example.demo.service.dto.ProductDTO;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.ArrayList;
import java.util.List;

@Service
@Transactional
public class ProductServiceImpl implements ProductService {

    private final ProductRepository productRepository;

    public ProductServiceImpl(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    @Override
    public List<ProductDTO> getAll(){
        List<Product> products = productRepository.findAllProduct();
        List<ProductDTO> productDTOS = new ArrayList<>();
        ModelMapper modelMapper = new ModelMapper();
        for (Product acc : products ) {
            productDTOS.add(modelMapper.map(acc, ProductDTO.class));

        }
        return productDTOS;
    }

//    @Override
//    Boolean delete(Integer id){
//        return 0;
//    }
//
//    @Override
//    ProductDTO insert(ProductDTO productDTO){}
//
//    @Override
//    ProductDTO update(ProductDTO productDTO){}

}
