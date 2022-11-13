using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOrRemove : MonoBehaviour
{
    
    /// <summary>
    /// Set this to +1 for Add and -1 for Remove
    /// </summary>
    /// <param name="type"></param>
    public void UpdateHoldings(int type)
    {
        if (type==-1 && CurrentListItem.Instance.holdings <= 0) return;
        CurrentListItem.Instance.holdings += type;
        CurrentListItem.Instance.UpdateVisual();
    }
}
