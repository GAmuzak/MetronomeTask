using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelectorManager : MonoBehaviour
{
    [SerializeField] private GameObject stockContainer;
    [SerializeField] private GameObject stockInfo;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private float moveSpeed;

    private List<InventoryItemSelection> items = new List<InventoryItemSelection>();
    private bool lerping = true;
}
