package com.example.demo.persistent.repository;

import com.example.demo.persistent.entity.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ProductRepository extends JpaRepository<Product, Integer> {
    @Query("SELECT p FROM Product p WHERE p.status = true ")
    List<Product> findAllProduct();

    @Query("SELECT p FROM  Product p WHERE p.categoryID = :catergoryID")
    List<Product> findByCategoryID(@Param("catergoryID") Integer catergoryID);

    @Query("update Product p set p.status = false where p.id = :id")
    @Modifying
    void deleteByID(@Param("id") Integer id);

    @Query("SELECT p FROM  Product p WHERE p.id = :id")
    Product findByID(@Param("id") Integer id);

//    @Query("update Product p set p.status = false where p.id = :id")
//    @Modifying
//    void deleteByID(@Param("id") Integer id);




}
