using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListItemHandler : MonoBehaviour
{
    public static event Action OnStockClick;
    public static event Action PreviousStockUpdate;
    
    public void OnListItemClick()
    {
        PreviousStockUpdate?.Invoke();
        
        Transform stock = transform.GetChild(0);
        CurrentListItem.Instance.stockType = stock.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        string cost = stock.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        CurrentListItem.Instance.cost=int.Parse(cost.Substring(0,cost.Length-3));
        CurrentListItem.Instance.multiplier=int.Parse(stock.GetChild(2).GetComponent<TextMeshProUGUI>().text.Substring(0, 1));
        CurrentListItem.Instance.holdings=int.Parse(stock.GetChild(3).GetComponent<TextMeshProUGUI>().text);
        CurrentListItem.Instance.stockTransform = stock;
        
        OnStockClick?.Invoke();
    }
}
