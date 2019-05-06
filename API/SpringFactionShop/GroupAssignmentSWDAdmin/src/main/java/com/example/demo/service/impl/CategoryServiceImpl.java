package com.example.demo.service.impl;

import com.example.demo.persistent.entity.Category;
import com.example.demo.persistent.repository.CategoryRepository;
import com.example.demo.service.CategoryService;
import com.example.demo.service.dto.CategoryDTO;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import javax.persistence.EntityNotFoundException;
import javax.transaction.Transactional;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
@Transactional
public class CategoryServiceImpl implements CategoryService {

    private final CategoryRepository categoryRepository;

    public CategoryServiceImpl(CategoryRepository categoryRepository) {
        this.categoryRepository = categoryRepository;
    }

    @Override
    public List<CategoryDTO> getAll(){
        List<Category> categories = categoryRepository.findAllByIsDelete();
        List<CategoryDTO> categoryDTOS = new ArrayList<>();
        ModelMapper modelMapper = new ModelMapper();
        for (Category ca : categories ) {
                    categoryDTOS.add(modelMapper.map(ca, CategoryDTO.class));
        }
        return categoryDTOS;
    }

    @Override
    public Boolean delete(Integer id){
        Optional.ofNullable(categoryRepository.findById(id)).orElseThrow(() ->new EntityNotFoundException());
        categoryRepository.deleteByID(id);
        return true;
    }

    @Override
    public CategoryDTO insert(CategoryDTO categoryDTO){
        ModelMapper modelMapper = new ModelMapper();
        Category category = modelMapper.map(categoryDTO, Category.class);
        category.setStatus(true);
        category = categoryRepository.save(category);
        CategoryDTO dto = modelMapper.map(category, CategoryDTO.class);
        return dto;
    }
}
