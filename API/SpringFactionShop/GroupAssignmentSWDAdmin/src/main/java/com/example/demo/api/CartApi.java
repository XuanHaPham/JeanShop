package main.java.com.example.demo.api;

import com.example.demo.service.dto.CartDTO;
import io.swagger.annotations.ApiOperation;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@Component
@RequestMapping("/cart")
public interface CartApi {
    @ApiOperation(tags = {"Cart",}, notes = "", value = "Get cart by account ID")
    @GetMapping("/getCartByAccountID")
    ResponseEntity<List<CartDTO>> getCartByAccountID(@RequestParam("accountID") Integer accountID);

    @ApiOperation(tags = {"Cart",}, notes = "", value = "delete cart by cart ID")
    @PostMapping("/deleteByID")
    ResponseEntity<Map<String, Boolean>> deleteByID(@RequestParam("id") Integer id);

    @ApiOperation(tags = {"Cart",}, notes = "", value = "insert cart")
    @PostMapping("")
    ResponseEntity<CartDTO> insert(@RequestBody CartDTO cartDTO);

    @ApiOperation(tags = {"Cart",}, notes = "", value = "update cart")
    @PutMapping("")
    ResponseEntity<CartDTO> update(@RequestBody CartDTO cartDTO);


}
