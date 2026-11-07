package com.ewallet.Models;

public abstract class User
{
    private String userId;
    private String name;

    public User(String userId, String name)
    {
        if (userId == null || userId.isBlank())
        {
            throw new IllegalArgumentException("UserId is required");
        }
        if (name == null || name.isBlank())
        {
            throw new IllegalArgumentException("Name is required");
        }

        this.userId = userId;
        this.name = name;
    }

    public String getUserId(){
        return userId;
    }

    public String getName(){
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public abstract double GetBalance();
    public abstract void ShowAccount();
}