package com.example.demo.persistent.repository;

import com.example.demo.persistent.entity.WishList;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface WishListRepository extends JpaRepository<WishList, Integer> {

    @Query("SELECT c FROM Cart c WHERE c.accountID = :accountID AND c.status = true")
    List<WishList> getWishlistByAccountID(@Param("accountID") Integer accountID);
}
