package com.example.demo.api;

import com.example.demo.service.dto.ProductDTO;
import io.swagger.annotations.ApiOperation;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@Component
@RequestMapping("/products")
public interface ProductApi {
    @ApiOperation(tags = {"Product",}, notes = "", value = "Get all product")
    @GetMapping("/getAllProduct")
    ResponseEntity<List<ProductDTO>> getAllProduct();

    @ApiOperation(tags = {"Product",}, notes = "", value = "Get all product by category id")
    @GetMapping("/findByCategoryID")
    ResponseEntity<List<ProductDTO>> findByCategoryID(@RequestParam("categoryID") Integer categoryID);

    @ApiOperation(tags = {"Product",}, notes = "", value = "Delete product by ID")
    @PostMapping("/deleteByID")
    ResponseEntity<Map<String, Boolean>> deleteByID(@PathVariable("id") Integer id);

    @ApiOperation(tags = {"Product",}, notes = "", value = "Get product by ID")
    @GetMapping("/findByID")
    ResponseEntity<ProductDTO> findByID(@PathVariable("id") Integer id);
}