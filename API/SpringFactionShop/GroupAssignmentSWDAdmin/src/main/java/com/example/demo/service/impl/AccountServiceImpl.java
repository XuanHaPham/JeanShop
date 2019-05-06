package com.example.demo.service.impl;

import com.example.demo.persistent.entity.Account;
import com.example.demo.persistent.entity.AccountRole;
import com.example.demo.persistent.repository.AccountRepository;
import com.example.demo.persistent.repository.AccountRoleRepository;
import com.example.demo.service.AccountService;
import com.example.demo.service.dto.AccountDTO;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;
import org.springframework.util.ObjectUtils;

import javax.persistence.EntityNotFoundException;
import javax.transaction.Transactional;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
@Transactional
public class AccountServiceImpl implements AccountService {

    private final AccountRepository accountRepository;
    private final AccountRoleRepository accountRoleRepository;


    public AccountServiceImpl(AccountRepository accountRepository, AccountRoleRepository accountRoleRepository) {
        this.accountRepository = accountRepository;
        this.accountRoleRepository = accountRoleRepository;
    }

    @Override
    public AccountDTO getByUsernameAndPassword(String username, String password) {
        Account account = accountRepository.findByUsernameAndPassword(username, password);
        if(ObjectUtils.isEmpty(account)) {
            return null;
        }
        ModelMapper modelMapper = new ModelMapper();
        AccountDTO accountDTO = modelMapper.map(account, AccountDTO.class);
        accountDTO.setRoleID(accountRoleRepository.getRoleIDByAccountID(account.getId()));
        return accountDTO;
    }

    @Override
    public List<AccountDTO> getAll() {
        List<Account> accounts = accountRepository.findAllByIsDelete();
        List<AccountDTO> accountDTOS = new ArrayList<>();
        ModelMapper modelMapper = new ModelMapper();
        for (Account acc : accounts ) {
            if(accountRoleRepository.getRoleIDByAccountID(acc.getId()) != null)
            if (accountRoleRepository.getRoleIDByAccountID(acc.getId()) == 1)
            accountDTOS.add(modelMapper.map(acc, AccountDTO.class));
        }
        return accountDTOS;
    }
    @Override
    public Boolean delete(Integer id) {
        Optional.ofNullable(accountRepository.findById(id)).orElseThrow(() ->new EntityNotFoundException());
        accountRepository.deleteByID(id);
        return true;
    }

    @Override
    public AccountDTO insert(AccountDTO accountDTO) {
        ModelMapper modelMapper = new ModelMapper();
        Account account = modelMapper.map(accountDTO, Account.class);
        account.setStatus(true);
        account = accountRepository.save(account);
        AccountRole accountRole = new AccountRole();
        accountRole.setRoleID(1);
        accountRole.setAccountID(account.getId());
        accountRole.setStatus(true);
        accountRoleRepository.save(accountRole);
        AccountDTO dto = modelMapper.map(account, AccountDTO.class);
        dto.setRoleID(1);
        return dto;
    }

    @Override
    public AccountDTO update(AccountDTO accountDTO) {
        Optional.ofNullable(accountRepository.findById(accountDTO.getId())).orElseThrow(() -> new EntityNotFoundException());
        ModelMapper modelMapper = new ModelMapper();
        Account account = modelMapper.map(accountDTO, Account.class);
        Account accountFlag = accountRepository.findAccountById(account.getId());
        account.setPassword(accountFlag.getPassword());
        account.setEmail(accountFlag.getEmail());
        account.setStatus(accountFlag.getStatus());
        account.setUsername(accountFlag.getUsername());
        account = accountRepository.saveAndFlush(account);
        AccountDTO dto = modelMapper.map(account, AccountDTO.class);
        return dto;
    }

    @Override
    public Boolean updatePassword(String  password, Integer id){
        Optional.ofNullable(accountRepository.findById(id)).orElseThrow(() ->new EntityNotFoundException());
        accountRepository.updatePassword(password, id);
        return true;
    }
}
