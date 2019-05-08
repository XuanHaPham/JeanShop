package com.example.demo.api.impl;

import com.example.demo.api.BillApi;
import com.example.demo.service.BillService;
import com.example.demo.service.dto.BillDetailDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@CrossOrigin(origins = "*", allowedHeaders = "*")
@RestController
public class BillController implements BillApi {

    @Autowired
    BillService billService;

    @Override
    public ResponseEntity<Map<String, Boolean>> create(@RequestBody List<BillDetailDTO> billDetailDTO,                                       @RequestParam Integer accountID){
        Boolean result = billService.create(billDetailDTO,accountID);
        Map<String, Boolean> resul = new HashMap<>();
        resul.put("Content", result);
        return ResponseEntity.ok(resul);
    }
}
