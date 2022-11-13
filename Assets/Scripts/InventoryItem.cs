using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Object", menuName = "ScriptableObjects/AssetObject", order=1)]
public class InventoryItem : ScriptableObject
{
    public StockType type;
    public int price;
    public int multiplier;
    public int holdings;
}

public enum StockType
{
    NULL=-1,
    Penny=0,
    SmallCap=1,
    MidCap=2,
    LargeCap=3
}