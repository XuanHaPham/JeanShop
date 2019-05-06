package com.example.demo.service.impl;


import com.example.demo.persistent.entity.Role;
import com.example.demo.persistent.repository.RoleRepository;
import com.example.demo.service.RoleService;
import com.example.demo.service.dto.RoleDTO;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import javax.persistence.EntityNotFoundException;
import javax.transaction.Transactional;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
@Transactional
public class RoleServeImpl implements RoleService {

    private final RoleRepository roleRepository;

    public RoleServeImpl(RoleRepository roleRepository) {
        this.roleRepository = roleRepository;
    }

    @Override
    public List<RoleDTO> getAll(){
        List<Role> roles = roleRepository.getAllRole();
        List<RoleDTO> roleDTOS = new ArrayList<>();
        ModelMapper modelMapper = new ModelMapper();
        for (Role r : roles ) {
                    roleDTOS.add(modelMapper.map(r, RoleDTO.class));
        }
        return roleDTOS;
    }

    @Override
    public Boolean delete(Integer id){
        Optional.ofNullable(roleRepository.findById(id)).orElseThrow(() ->new EntityNotFoundException());
        roleRepository.deleteByID(id);
        return true;
    }

    @Override
    public RoleDTO insert(RoleDTO roleDTO){
        ModelMapper modelMapper = new ModelMapper();
        Role role = modelMapper.map(roleDTO, Role.class);
        role.setStatus(true);
        role = roleRepository.save(role);
        RoleDTO dto = modelMapper.map(role, RoleDTO.class);
        return dto;
    }
}
