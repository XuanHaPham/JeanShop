package com.example.demo.persistent.repository;

import com.example.demo.persistent.entity.Feedback;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface FeedbackRepository extends JpaRepository<Feedback, Integer> {
    @Query("SELECT f FROM Feedback f WHERE f.status = true ")
    List<Feedback> findALl();

    @Query("UPDATE Feedback f SET f.status = false WHERE f.id = :id")
    @Modifying
    void deleteByIDModify(@Param("id") Integer id);

}
