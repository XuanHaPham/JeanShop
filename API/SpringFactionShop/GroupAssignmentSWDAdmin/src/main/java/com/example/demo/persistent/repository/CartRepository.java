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
    @Query("SELECT c FROM Cart c WHERE c.accountID = :accountID AND c.status = true")
    List<Cart> getCartByAccountID(@Param("accountID") Integer accountID);

    @Query("UPDATE Cart c SET c.status = false WHERE c.id = :id")
    @Modifying
    void deleteByID(Integer id);


}