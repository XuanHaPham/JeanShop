package com.example.demo.service.impl;

import com.example.demo.persistent.entity.Account;
import com.example.demo.persistent.entity.Cart;
import com.example.demo.persistent.repository.CartRepository;
import com.example.demo.service.CartService;
import com.example.demo.service.dto.AccountDTO;
import com.example.demo.service.dto.CartDTO;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;
import org.springframework.util.ObjectUtils;

import javax.persistence.EntityNotFoundException;
import javax.transaction.Transactional;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
@Transactional
public class CartServiceImpl implements CartService {

    private final CartRepository cartRepository;

    public CartServiceImpl(CartRepository cartRepository) {
        this.cartRepository = cartRepository;
    }

    @Override
    public List<CartDTO> getCartByAccountID(Integer accountID){
        List<Cart> carts = cartRepository.getCartByAccountID(accountID);
        List<CartDTO> cartDTOrs = new ArrayList<>();
        ModelMapper modelMapper = new ModelMapper();
        for (Cart cart : carts ) {
            cartDTOrs.add(modelMapper.map(cart, CartDTO.class));

        }
        return cartDTOrs;
    }

    @Override
    public Boolean deleteByID(Integer id){
        Optional.ofNullable(cartRepository.findById(id)).orElseThrow(() ->new EntityNotFoundException());
        cartRepository.deleteByID(id);
        return true;
    }

    @Override
    public CartDTO insert(CartDTO cartDTO){
        ModelMapper modelMapper = new ModelMapper();
        Cart cart = modelMapper.map(cartDTO, Cart.class);
        cart = cartRepository.save(cart);
        CartDTO dto = modelMapper.map(cart, CartDTO.class);
        return dto;
    }

    @Override
    public CartDTO update(CartDTO cartDTO){
        Optional.ofNullable(cartRepository.findById(cartDTO.getId())).orElseThrow(() -> new EntityNotFoundException());
        ModelMapper modelMapper = new ModelMapper();
        Cart cart = modelMapper.map(cartDTO, Cart.class);
        cart = cartRepository.saveAndFlush(cart);
        CartDTO dto = modelMapper.map(cart, CartDTO.class);
        return dto;
    }

}
