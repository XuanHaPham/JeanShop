package com.example.demo.service;

import com.example.demo.service.dto.ProductDTO;

import java.util.List;

public interface ProductService {

    List<ProductDTO> getAll();

    List<ProductDTO> findByCategoryID(Integer id);

    Boolean deleteByID(Integer id);

    ProductDTO findByID(Integer id);

    ProductDTO insert(ProductDTO productDTO);

    ProductDTO update(ProductDTO productDTO);
}
