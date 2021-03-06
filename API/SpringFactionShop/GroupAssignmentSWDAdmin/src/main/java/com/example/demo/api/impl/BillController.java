package com.example.demo.api.impl;

import com.example.demo.api.BillApi;
import com.example.demo.service.BillService;
import com.example.demo.service.dto.BillDTO;
import com.example.demo.service.dto.BillDetailDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@CrossOrigin(origins = "*", allowedHeaders = "*")
@RestController
public class BillController implements BillApi {

    @Autowired
    BillService billService;

    @Override
    public ResponseEntity<Map<String, Boolean>> create(@RequestBody List<BillDetailDTO> billDetailDTO,@PathVariable Integer accountID){
        Boolean result = billService.create(billDetailDTO,accountID);
        Map<String, Boolean> resul = new HashMap<>();
        resul.put("Content", result);
        return ResponseEntity.ok(resul);
    }

    @Override
    public ResponseEntity<List<BillDTO>> getAllBill(){
        List<BillDTO> billDTOS = billService.getAllBill();
        return ResponseEntity.ok(billDTOS);
    }

    @Override
    public ResponseEntity<List<BillDetailDTO>> getAllProductOfBill(@PathVariable Integer billID){
        List<BillDetailDTO> billDetailDTOS = billService.getAllProductOfBill(billID);
        return ResponseEntity.ok(billDetailDTOS);
    }

    @Override
    public  ResponseEntity<Map<String, Boolean>> updateBillStatus(@PathVariable Integer id){
        Boolean result = billService.updateStatus(id);
        Map<String, Boolean> resul = new HashMap<>();
        resul.put("Content", result);
        return ResponseEntity.ok(resul);
    }
}
