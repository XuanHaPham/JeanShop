package com.example.demo.api;

import com.example.demo.service.dto.AccountDTO;
import com.example.demo.service.dto.CategoryDTO;
import io.swagger.annotations.ApiOperation;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@CrossOrigin(origins = "*", allowedHeaders = "*")
@Component
@RequestMapping("/category")
public interface CategoryApi {
    @ApiOperation(tags = {"Category",}, notes = "", value = "Create new Category")
    @PostMapping("")
    ResponseEntity<CategoryDTO> create(@RequestBody CategoryDTO categoryDTO);

    @ApiOperation(tags = {"Category",}, notes = "", value = "Get All Category")
    @GetMapping("")
    ResponseEntity<List<CategoryDTO>> getAll();

    @ApiOperation(tags = {"Category",}, notes = "", value = "Delete Category")
    @DeleteMapping("/{id}")
    ResponseEntity<Map<String, Boolean>> delete(@PathVariable("id") Integer id);
}
