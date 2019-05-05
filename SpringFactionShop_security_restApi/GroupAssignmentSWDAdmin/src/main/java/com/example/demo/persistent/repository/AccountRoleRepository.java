package com.example.demo.persistent.repository;

import com.example.demo.persistent.entity.Account;
import com.example.demo.persistent.entity.AccountRole;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;


@Repository
public interface AccountRoleRepository extends JpaRepository<AccountRole, Integer> {

}
