package com.example.demo.persistent.repository;

import com.example.demo.persistent.entity.WishList;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.data.jpa.repository.Modifying;

import java.util.List;

@Repository
public interface WishListRepository extends JpaRepository<WishList, Integer> {

    /*@Query("SELECT w FROM WishList w WHERE w.accountID = :accountID AND w.status = true")
    List<WishList> getWishlistByAccountID(@Param("accountID") Integer accountID);*/

    @Query("SELECT w FROM WishList w WHERE w.accountID = :accountID AND w.status = true")
    List<WishList> getWishlistByAccountID(@Param("accountID") Integer accountID);

    @Query("UPDATE w FROM WishList SET w.status=false WHERE w.status=true AND w.accountID = :accountID AND w.productID = :productID")
    @Modifying
    boolean deleteProductFromWishList(@Param("accountID") Integer accountID, @Param("productID") Integer productID);

}
