package com.example.demo.persistent.entity;

import io.swagger.models.auth.In;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name = "bill")
public class Bill {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Integer id;

    @Column(name = "account_id")
    private Integer accountID;

    @Column(name = "deliver_id")
    private Integer deliverID;

    @Column(name = "sub_total")
    private float subTotal;

    @Column(name = "shipping_fee")
    private float shippingFree;

    @Column(name = "total")
    private float total;

    @Column(name = "note_for_deliver")
    private String noteForDeliver;

    @Column(name = "time_created")
    private Date timeCreated;

    @Column(name = "status")
    private Boolean status;

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
