package com.example.demo.api.impl;


import com.example.demo.api.CartApi;
import com.example.demo.persistent.entity.Cart;
import com.example.demo.service.CartService;
import com.example.demo.service.dto.CartDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@CrossOrigin(origins = "*", allowedHeaders = "*")
@RestController
public class CartController implements CartApi {

    @Autowired
    CartService cartService;

    @Override
    public ResponseEntity<List<CartDTO>> getCartByAccountID(@RequestParam("accountID") Integer accountID){
        List<CartDTO> cartDTOS = cartService.getCartByAccountID(accountID);
        return ResponseEntity.ok(cartDTOS);
    }

    @Override
    public ResponseEntity<Map<String, Boolean>> deleteByID(@RequestParam("id") Integer id){
        Boolean result = cartService.deleteByID(id);
        Map<String, Boolean> resul = new HashMap<>();
        resul.put("Content", result);
        return ResponseEntity.ok(resul);
    }

    @Override
    public ResponseEntity<CartDTO> insert(@RequestBody CartDTO cartDTO){
        CartDTO dto = cartService.insert(cartDTO);
        return ResponseEntity.ok(dto);
    }

    @Override
    public  ResponseEntity<CartDTO> update(@RequestBody CartDTO cartDTO){
        CartDTO dto = cartService.update(cartDTO);
        return ResponseEntity.ok(dto);
    }
}
