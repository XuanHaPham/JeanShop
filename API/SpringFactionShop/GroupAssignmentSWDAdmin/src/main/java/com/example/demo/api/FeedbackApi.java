package com.example.demo.api;

import com.example.demo.service.dto.FeedbackDTO;
import io.swagger.annotations.ApiOperation;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@CrossOrigin(origins = "*", allowedHeaders = "*")
@Component
@RequestMapping("/feedback")
public interface FeedbackApi {

    @ApiOperation(tags = {"Feedback",}, notes = "", value = "get all feedback")
    @GetMapping("/getAll")
    ResponseEntity<List<FeedbackDTO>> getAll();

    @ApiOperation(tags = {"Feedback",}, notes = "", value = "delete feedback by id")
    @DeleteMapping("/{id}")
    ResponseEntity<Map<String, Boolean>> delete(@PathVariable("id") Integer id);

    @ApiOperation(tags = {"Feedback",}, notes = "", value = "get all feedback")
    @PostMapping("")
    ResponseEntity<FeedbackDTO> insert(@RequestBody FeedbackDTO accountDTO);


}
