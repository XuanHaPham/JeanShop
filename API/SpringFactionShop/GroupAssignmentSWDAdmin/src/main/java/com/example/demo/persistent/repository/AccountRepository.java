package com.example.demo.persistent.repository;

import com.example.demo.persistent.entity.Account;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface AccountRepository extends JpaRepository<Account, Integer> {

    @Query("SELECT a FROM Account a WHERE a.email = :username AND a.password = :password AND a.status = true")
    Account findByUsernameAndPassword(@Param("username") String username, @Param("password") String password);

    @Query("SELECT a FROM Account a WHERE a.id = :id AND a.status = true")
    Account findAccountById(@Param("id") Integer id);

    @Query("SELECT a FROM Account a WHERE a.status = false ")
    List<Account> findAllByIsDelete();

    @Query("UPDATE Account a SET a.status = false WHERE a.id = :id")
    @Modifying
    void deleteByID(Integer id);

    @Query("UPDATE Account a SET a.password = :password WHERE a.id = :id")
    @Modifying
    void updatePassword(@Param("password") String password, @Param("id") Integer id);

}
