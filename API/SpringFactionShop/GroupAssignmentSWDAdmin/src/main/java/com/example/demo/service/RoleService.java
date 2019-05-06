package com.example.demo.service;

import com.example.demo.service.dto.RoleDTO;

import java.util.List;

public interface RoleService {

    List<RoleDTO> getAll();

    Boolean delete(Integer id);

    RoleDTO insert(RoleDTO roleDTO);

}
