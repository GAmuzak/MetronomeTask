using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlighterHandler : MonoBehaviour
{
    [SerializeField] private float animTime;
    [SerializeField] private Vector3 visualOffset;
    [SerializeField] private LeanTweenType easeCurve;
    
    private void OnEnable()
    {
        ListItemHandler.OnStockClick += HighlighterPositionUpdate;
    }

    private void OnDisable()
    {
        ListItemHandler.OnStockClick -= HighlighterPositionUpdate;
    }

    private void HighlighterPositionUpdate()
    {
        Vector3 targetPosition = CurrentListItem.Instance.stock.position + visualOffset;
        LeanTween.move(gameObject, targetPosition, animTime).setEase(easeCurve);
    }
}
