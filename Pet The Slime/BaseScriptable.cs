using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScriptable : ScriptableObject
{
    [SerializeField] int cost;
    [SerializeField] bool isPurchased;

    public int GetCost()
    {
        return cost;
    }
    public void SetCost(int x)
    {
        cost = x;
    }
    public bool IsPurchased()
    {
        return isPurchased;
    }
    public void setPurchased()
    {
        isPurchased = true;
    }
    public void Reset()
    {
        isPurchased = false;
    }
}
