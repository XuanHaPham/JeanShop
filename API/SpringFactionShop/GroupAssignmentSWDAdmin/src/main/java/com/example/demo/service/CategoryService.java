package com.example.demo.service;

import com.example.demo.service.dto.CategoryDTO;

import java.util.List;

public interface CategoryService {

    List<CategoryDTO> getAll();

    Boolean delete(Integer id);

    CategoryDTO insert(CategoryDTO categoryDTO);
}
