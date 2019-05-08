package com.example.demo.persistent.repository;


import com.example.demo.persistent.entity.Bill;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface BillRepository extends JpaRepository<Bill, Integer> {
    @Query("SELECT b FROM Bill b")
    List<Bill> findAllByIsDelete();
}
