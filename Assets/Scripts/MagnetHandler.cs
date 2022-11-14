using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetHandler : MonoBehaviour
{
    [SerializeField] private GameObject magnet;
    [SerializeField] private Transform stocksHolder;

    private bool rearranging = true;
    private void Start()
    {
        // foreach (Transform magnet in transform)
        // {
        //     Debug.Log(magnet.name+"  "+magnet.position);
        //      
        // Debug.Log($"StockObject = {stocksHolder.GetChild(i).transform.position}");
        // Debug.Log($"MagnetObject = {transform.GetChild(i).transform.position}");
        // // }
        
        
    }

    private void Update()
    {
        if (!rearranging) return;
        for (int i = 0; i < transform.childCount; i++)
        {
            stocksHolder.GetChild(i).transform.position = new Vector3(transform.GetChild(i).transform.position.x,transform.GetChild(i).transform.position.y,0f);
        }
    }
}
