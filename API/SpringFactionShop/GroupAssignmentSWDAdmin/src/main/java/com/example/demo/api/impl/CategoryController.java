package com.example.demo.api.impl;


import com.example.demo.api.CategoryApi;
import com.example.demo.service.CategoryService;
import com.example.demo.service.dto.CategoryDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@CrossOrigin(origins = "*", allowedHeaders = "*")
@RestController
public class CategoryController implements CategoryApi {

    @Autowired
    CategoryService categoryService;

    @Override
    public ResponseEntity<CategoryDTO> create(@RequestBody CategoryDTO categoryDTO) {
        CategoryDTO dto = categoryService.insert(categoryDTO);
        return ResponseEntity.ok(dto);
    }

    @Override
    public ResponseEntity<List<CategoryDTO>> getAll() {
        List<CategoryDTO> categoryDTOS = categoryService.getAll();
        return ResponseEntity.ok(categoryDTOS);
    }

    @Override
    public ResponseEntity<Map<String, Boolean>> delete(@PathVariable("id") Integer id) {
        Boolean result = categoryService.delete(id);
        Map<String, Boolean> resul = new HashMap<>();
        resul.put("Content", result);
        return ResponseEntity.ok(resul);
    }
}
