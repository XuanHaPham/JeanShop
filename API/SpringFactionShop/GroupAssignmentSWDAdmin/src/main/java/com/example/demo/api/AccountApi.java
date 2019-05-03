package com.example.demo.api;

import com.example.demo.service.dto.AccountDTO;
import io.swagger.annotations.ApiOperation;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@Component
@RequestMapping("/accounts")
public interface AccountApi {

    @ApiOperation(tags = {"Account",}, notes = "", value = "Create new Account")
    @PostMapping("")
    ResponseEntity<AccountDTO> create(@RequestBody AccountDTO accountDTO);

    @ApiOperation(tags = {"Account",}, notes = "", value = "Update Account")
    @PutMapping("")
    ResponseEntity<AccountDTO> update(@RequestBody AccountDTO accountDTO);

    @ApiOperation(tags = {"Account",}, notes = "", value = "Get All Account")
    @GetMapping("")
    ResponseEntity<List<AccountDTO>> getAll();

    @ApiOperation(tags = {"Account",}, notes = "", value = "Delete Account")
    @DeleteMapping("/{id}")
    ResponseEntity<Map<String, Boolean>> delete(@PathVariable("id") Integer id);

    @ApiOperation(tags = {"Account",}, notes = "", value = "Update password")
    @PostMapping("/updatePassword")
    ResponseEntity<Map<String, Boolean>> updatePassword(@PathVariable("password") String password,@PathVariable("sid") Integer id);

}
