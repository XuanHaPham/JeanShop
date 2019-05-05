package com.example.demo.service.impl;

import com.example.demo.persistent.entity.Account;
import com.example.demo.persistent.repository.AccountRepository;
import java.util.Optional;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import java.util.Collections;

@Service
public class UserDetailsServiceImpl implements UserDetailsService {
    private final AccountRepository userRepository;

    public UserDetailsServiceImpl(AccountRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
            Optional<Account> optionalUser = userRepository.findByName(username);

        Account user = null;

        if (optionalUser.isPresent()) {
            user = optionalUser.get();
        }

        if (user == null) {
            throw new UsernameNotFoundException(username);
        }

        return new org.springframework.security.core.userdetails.User(user.getUsername(), user.getPassword(), Collections.emptyList());
    }
}
