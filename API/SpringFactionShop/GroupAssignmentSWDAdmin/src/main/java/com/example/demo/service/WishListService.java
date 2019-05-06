package main.java.com.example.demo.service;

import com.example.demo.service.dto.WishListDTO;
import main.java.com.example.demo.service.dto.WishListDTO;

import java.util.List;

public interface WishListService {

    List<WishListDTO> getByAccountID(Integer accountID);

    WishListDTO insert(WishListDTO wishListDTO);

    WishListDTO updateStatus(WishListDTO wishListDTO);
}