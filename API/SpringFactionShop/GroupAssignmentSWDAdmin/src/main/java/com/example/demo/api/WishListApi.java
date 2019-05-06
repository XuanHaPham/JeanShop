package main.java.com.example.demo.api;

import main.java.com.example.demo.service.dto.WishListDTO;

@Component
@RequestMapping("/wishLists")
public interface WishListApi {

    @ApiOperation(tags = {"WishList",}, notes = "", value = "View customer wishlist")
    @GetMapping("/accountID")
    ResponseEntity<List<WishListDTO>> getWishlistByAccountID(@RequestParam("accountID") Integer accountID);

    @ApiOperation(tags = {"WishList",}, notes = "", value = "Delete a product from wishlist")
    @PutMapping("/accountID/productID")
    ResponseEntity<WishListDTO> deleteProductFromWishList(@RequestParam("accountID") Integer accountID,
                                                          @RequestParam("productID") Integer productID);

    @ApiOperation(tags = {"WishList",}, notes= "", value = "Add new Product to Wishlist")
    @PostMapping("/accountID/productID")
    ResponseEntity<WishListDTO> addProductToWishList(@RequestParam("accountID") Integer accountID, @RequestParam("productID") Integer productID);

}
