package main.java.com.example.demo.api.impl;

import main.java.com.example.demo.api.WishListApi;
import main.java.com.example.demo.service.WishListService;
import main.java.com.example.demo.service.dto.WishListDTO;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class WishListController implements WishListApi {

    @Autowired
    WishListService wishListService;

    @Override
    public ResponseEntity<List<WishListDTO>> getWishlistByAccountID(Integer accountID) {
        List<WishListDTO> wishListDTOS = wishListService.getByAccountID(accountID);
        return ResponseEntity.ok(accountDTOS);
    }

    @Override
    public ResponseEntity<WishListDTO> deleteProductFromWishList(Integer accountID, Integer productID) {
        WishListDTO wishListDTO = new WishListDTO();
        wishListDTO.setAccountID(accountID);
        wishListDTO.setStatus(false);
        WishListDTO result = wishListService.updateStatus(wishListDTO);
        Map<String , WishListDTO> resul = new HashMap<>();
        resul.put("Content", result);
        return ResponseEntity.ok(resul);
    }

    @Override
    public ResponseEntity<WishListDTO> addProductToWishList(Integer accountID, Integer productID) {
        WishListDTO wishListDTO = new WishListDTO();
        wishListDTO.setAccountID(accountID);
        wishListDTO.setStatus(false);
        WishListDTO dto = wishListService.insert(wishListDTO);
        return ResponseEntity.ok(dto);
    }
}
