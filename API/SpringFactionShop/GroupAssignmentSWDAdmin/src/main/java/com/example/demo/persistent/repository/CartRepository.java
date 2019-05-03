package com.example.demo.persistent.repository;

import com.example.demo.persistent.entity.Cart;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface CartRepository extends JpaRepository<Cart, Integer> {
    @Query("SELECT a FROM Account a WHERE a.username = :username AND a.password = :password AND a.status = false")
    Cart findByUsernameAndPassword(@Param("username") String username, @Param("password") String password);

    @Query("SELECT a FROM Account a WHERE a.status = false ")
    List<Cart> findAllByIsDelete();

    @Query("UPDATE Account a SET a.status = false WHERE a.id = :id")
    @Modifying
    void deleteByID(Integer id);
}
