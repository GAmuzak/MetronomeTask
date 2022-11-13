using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListItemHandler : MonoBehaviour
{
    public static event Action OnStockClick;
    public void OnListItemClick()
    {
        Transform stock = transform.GetChild(0);
        CurrentListItem.Instance.stockType = stock.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        string cost = stock.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        CurrentListItem.Instance.cost=int.Parse(cost.Substring(0,cost.Length-3));
        CurrentListItem.Instance.multiplier=int.Parse(stock.GetChild(2).GetComponent<TextMeshProUGUI>().text.Substring(0, 1));
        CurrentListItem.Instance.holdings=int.Parse(stock.GetChild(3).GetComponent<TextMeshProUGUI>().text);
        CurrentListItem.Instance.stock = stock;
        
        OnStockClick?.Invoke();
    }

    private void UpdateVisual()
    {
        int holdings = CurrentListItem.Instance.holdings;
        string targetString = holdings.ToString();
        if (holdings < 10) targetString= "0" + targetString;
        transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = targetString;
    }
}
