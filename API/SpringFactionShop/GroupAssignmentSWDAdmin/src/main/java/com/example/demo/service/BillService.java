package com.example.demo.service;

import com.example.demo.service.dto.BillDetailDTO;

import java.util.List;

public interface BillService {
    Boolean create(List<BillDetailDTO> billDetailDTOS, Integer accountID);
}
