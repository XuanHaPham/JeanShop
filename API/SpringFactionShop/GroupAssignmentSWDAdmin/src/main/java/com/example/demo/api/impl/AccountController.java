package com.example.demo.api.impl;

import com.example.demo.api.AccountApi;
import com.example.demo.service.AccountService;
import com.example.demo.service.dto.AccountDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@RestController
public class AccountController implements AccountApi {

    @Autowired
    AccountService accountService;

    @Override
    public ResponseEntity<AccountDTO> create(@RequestBody AccountDTO accountDTO) {
        AccountDTO dto = accountService.insert(accountDTO);
        return ResponseEntity.ok(dto);
    }

    @Override
    public ResponseEntity<AccountDTO> update(@RequestBody AccountDTO accountDTO) {
        AccountDTO result = accountService.update(accountDTO);
        return ResponseEntity.ok(result);
    }

    @Override
    public ResponseEntity<List<AccountDTO>> getAll() {
        List<AccountDTO> accountDTOS = accountService.getAll();
        return ResponseEntity.ok(accountDTOS);
    }

    @Override
    public ResponseEntity<Map<String, Boolean>> delete(@PathVariable("id") Integer id) {
        Boolean result = accountService.delete(id);
        Map<String, Boolean> resul = new HashMap<>();
        resul.put("Content", result);
        return ResponseEntity.ok(resul);
    }

    @Override
    public ResponseEntity<Map<String, Boolean>> updatePassword(@PathVariable("password") String password,
                                                               @PathVariable("id") Integer id){
        Boolean result = accountService.updatePassword(password, id);
        Map<String , Boolean> resul = new HashMap<>();
        resul.put("Content", result);
        return ResponseEntity.ok(resul);
    }
}
