package com.example.demo.api.impl;

import com.example.demo.api.FeedbackApi;
import com.example.demo.service.FeedbackService;
import com.example.demo.service.dto.FeedbackDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@CrossOrigin(origins = "*", allowedHeaders = "*")
@RestController
public class FeedbackController implements FeedbackApi {

    @Autowired
    FeedbackService feedbackService;

    @Override
    public ResponseEntity<List<FeedbackDTO>> getAll(){
        List<FeedbackDTO> feedbackDTOS= feedbackService.getAll();
        return ResponseEntity.ok(feedbackDTOS);
    }

    @Override
    public ResponseEntity<Map<String, Boolean>> deleteByID(@PathVariable("id") Integer id){
        Boolean result = feedbackService.deleteByID(id);
        Map<String, Boolean> resul = new HashMap<>();
        resul.put("Content", result);
        return ResponseEntity.ok(resul);
    }

    @Override
    public ResponseEntity<FeedbackDTO> insert(@RequestBody FeedbackDTO feedbackDTO){
        FeedbackDTO dto = feedbackService.insert(feedbackDTO);
        return ResponseEntity.ok(dto);
    }
}
