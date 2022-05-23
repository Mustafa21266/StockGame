using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StockPurchase
{
    public DateTime purchaseDate;
    public int id;
    public Profile stockProfile;

    public float totalDue;

    public int numOfShares;

    public StockPurchase(int id ,int numOfShares, float totalDue, Profile stockProfile, DateTime purchaseDate)
    {
        this.numOfShares = numOfShares;
        this.id = id;
        this.totalDue = totalDue;
        this.stockProfile = stockProfile;
        this.purchaseDate = purchaseDate;
    }
}
