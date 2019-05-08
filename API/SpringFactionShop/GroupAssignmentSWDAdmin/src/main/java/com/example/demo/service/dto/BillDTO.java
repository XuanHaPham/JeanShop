package com.example.demo.service.dto;

import java.io.Serializable;
import java.util.Date;

public class BillDTO implements Serializable {

    private Integer id;

    private Integer accountID;

    private Integer deliverID;

    private float subTotal;

    private float shippingFree;

    private float total;

    private String noteForDeliver;

    private Date timeCreated;

    private Boolean status;

    private String customerEmail;


    public String getCustomerEmail() {
        return customerEmail;
    }

    public void setCustomerEmail(String customerEmail) {
        this.customerEmail = customerEmail;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getAccountID() {
        return accountID;
    }

    public void setAccountID(Integer accountID) {
        this.accountID = accountID;
    }

    public Integer getDeliverID() {
        return deliverID;
    }

    public void setDeliverID(Integer deliverID) {
        this.deliverID = deliverID;
    }

    public float getSubTotal() {
        return subTotal;
    }

    public void setSubTotal(float subTotal) {
        this.subTotal = subTotal;
    }

    public float getShippingFree() {
        return shippingFree;
    }

    public void setShippingFree(float shippingFree) {
        this.shippingFree = shippingFree;
    }

    public float getTotal() {
        return total;
    }

    public void setTotal(float total) {
        this.total = total;
    }

    public String getNoteForDeliver() {
        return noteForDeliver;
    }

    public void setNoteForDeliver(String noteForDeliver) {
        this.noteForDeliver = noteForDeliver;
    }

    public Date getTimeCreated() {
        return timeCreated;
    }

    public void setTimeCreated(Date timeCreated) {
        this.timeCreated = timeCreated;
    }

    public Boolean getStatus() {
        return status;
    }

    public void setStatus(Boolean status) {
        this.status = status;
    }
}
