package main.java.com.example.demo.service.impl;

import main.java.com.example.demo.service.WishListService;
import main.java.com.example.demo.service.dto.WishListDTO;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class WishListServiceImpl implements WishListService {

    private final com.example.demo.persistent.repository.WishListRepository wishListRepository;


    public WishListServiceImpl(com.example.demo.persistent.repository.WishListRepository wishListRepository) {
        this.wishListRepository = wishListRepository;
    }

    @Override
    public List<WishListDTO> getByAccountID(Integer accountID) {
        List<com.example.demo.persistent.entity.WishList> wishList = wishListRepository.getWishlistByAccountID(accountID);
        List<WishListDTO> wishListDTOS = new ArrayList<>();
        ModelMapper modelMapper = new ModelMapper();
        for (com.example.demo.persistent.entity.WishList wListRecord : wishList ) {
            wishListDTOS.add(modelMapper.map(wListRecord, WishListDTO.class));
        }
        return wishListDTOS;
    }

    @Override
    public WishListDTO insert(WishListDTO wishListDTO) {
        ModelMapper modelMapper = new ModelMapper();
        com.example.demo.persistent.entity.WishList wishListRecord =
                modelMapper.map(wishListDTO, com.example.demo.persistent.entity.WishList.class);
        wishListRecord = wishListRepository.save(wishListRecord);
        WishListDTO dto = modelMapper.map(wishList, WishListDTO.class);
        return dto;
    }

    @Override
    public WishListDTO updateStatus(WishListDTO wishListDTO) {
        Optional.ofNullable(wishListRepository.findByAccountId(wishListDTO.getAccountId())).orElseThrow(() -> new EntityNotFoundException());
        ModelMapper modelMapper = new ModelMapper();
        com.example.demo.persistent.entity.WishList wishList = modelMapper.map(wishListDTO, com.example.demo.persistent.entity.WishList.class);
        wishList = wishListRepository.saveAndFlush(wishList);
        WishListDTO dto = modelMapper.map(wishList, WishListDTO.class);
        return dto;
    }
}
