package com.ewallet.Services;

import java.util.List;

import com.ewallet.Models.User;

public class UserServices
{
    public static void ShowUser(List<User> walletsUsers)
    {
        var i = 1;
        for(User item : walletsUsers){
            System.out.println(i + ". " + item.getName());
            i++;
        }
        System.out.println("4. Exit");
    }
}