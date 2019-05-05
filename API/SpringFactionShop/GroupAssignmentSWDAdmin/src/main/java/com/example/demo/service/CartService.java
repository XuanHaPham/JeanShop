package com.example.demo.service;

import com.example.demo.service.dto.CartDTO;

import java.util.List;

public interface CartService {

    List<CartDTO> getCartByAccountID(Integer accountID);

    Boolean deleteByID(Integer id);

    CartDTO insert(CartDTO cartDTO);

    CartDTO update(CartDTO cartDTO);
}
