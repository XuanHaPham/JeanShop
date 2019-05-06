package com.example.demo.persistent.repository;

import com.example.demo.persistent.entity.Category;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface CategoryRepository extends JpaRepository<Category, Integer> {

    @Query("SELECT c FROM Category c WHERE c.status = true")
    List<Category> findAllByIsDelete();

    @Query("UPDATE Category c SET c.status = false WHERE c.id = :id")
    @Modifying
    void deleteByID(@Param("id") Integer id);

}
