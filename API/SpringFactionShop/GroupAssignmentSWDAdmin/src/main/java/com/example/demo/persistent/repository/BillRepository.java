package com.example.demo.persistent.repository;


import com.example.demo.persistent.entity.Bill;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface BillRepository extends JpaRepository<Bill, Integer> {
    @Query("SELECT b FROM Bill b")
    List<Bill> findAllByIsDelete();

    @Query("SELECT b FROM Bill b WHERE b.id = :id")
    Bill findBillByID(@Param("id") Integer id);

    @Query("UPDATE Bill b SET b.status = :status WHERE b.id = :id")
    @Modifying
    void deleteByID(@Param("id") Integer id, @Param("status") Boolean status);
}
