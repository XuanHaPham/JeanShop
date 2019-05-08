package com.example.demo.persistent.repository;

import com.example.demo.persistent.entity.BillDetail;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface BillDetailRepository extends JpaRepository<BillDetail, Integer> {
    @Query("SELECT b FROM BillDetail b where b.billID = :billID")
    List<BillDetail> findAllByIsDelete(@Param("billID") Integer billID);
}
