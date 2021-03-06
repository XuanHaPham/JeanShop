package com.example.demo.api;


import com.example.demo.service.dto.BillDTO;
import com.example.demo.service.dto.BillDetailDTO;
import io.swagger.annotations.ApiOperation;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@CrossOrigin(origins = "*", allowedHeaders = "*")
@Component
@RequestMapping("/bills")
public interface BillApi {
    @ApiOperation(tags = {"Bill",}, notes = "", value = "Create new Bill")
    @PostMapping("{accountID}")
    ResponseEntity<Map<String, Boolean>> create(@RequestBody List<BillDetailDTO> billDetailDTO,
                                                @PathVariable Integer accountID);

    @ApiOperation(tags = {"Bill",}, notes = "", value = "Get All Bill")
    @GetMapping("")
    ResponseEntity<List<BillDTO>> getAllBill();

    @ApiOperation(tags = {"Bill",}, notes = "", value = "get all product in Bill")
    @GetMapping("{billID}")
    ResponseEntity<List<BillDetailDTO>> getAllProductOfBill(@PathVariable Integer billID);

    @ApiOperation(tags = {"Bill",}, notes = "", value = "Update status of bill")
    @PutMapping("/updateBillStatus/{id}")
    ResponseEntity<Map<String, Boolean>> updateBillStatus(@PathVariable Integer id);
}
