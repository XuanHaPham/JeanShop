package com.example.demo.service;

import com.example.demo.persistent.entity.Feedback;
import com.example.demo.service.dto.FeedbackDTO;

import java.util.List;

public interface FeedbackService {

    List<FeedbackDTO> getAll();

    Boolean deleteByID(Integer id);

    FeedbackDTO insert(FeedbackDTO feedbackDTO);
}
