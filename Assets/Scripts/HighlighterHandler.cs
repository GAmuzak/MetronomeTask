using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlighterHandler : MonoBehaviour
{
    [SerializeField] private float animTime;
    [SerializeField] private Vector3 visualOffset;
    [SerializeField] private LeanTweenType easeCurve;

    private Image highlighter;
    private Image stockHighlighter;

    private void OnEnable()
    {
        ListItemHandler.OnStockClick += HighlighterPositionUpdate;
        ListItemHandler.PreviousStockUpdate += PrevStockHighlightDisable;
    }

    private void OnDisable()
    {
        ListItemHandler.OnStockClick -= HighlighterPositionUpdate;
        ListItemHandler.PreviousStockUpdate += PrevStockHighlightDisable;
    }

    private void PrevStockHighlightDisable()
    {
        if (CurrentListItem.Instance.stockTransform == null) return;
        CurrentListItem.Instance.stockTransform.parent.gameObject.GetComponent<Image>().enabled = false;
        transform.position = CurrentListItem.Instance.stockTransform.position;
    }
    
    private void HighlighterPositionUpdate()
    {
        
        GetComponent<Image>().enabled = true;
        Vector3 targetPosition = CurrentListItem.Instance.stockTransform.position + visualOffset;
        LeanTween.move(gameObject, targetPosition, animTime).setEase(easeCurve);
        StartCoroutine(WaitForAnim(animTime));
    }

    private IEnumerator WaitForAnim(float animTime)
    {
        yield return new WaitForSeconds(animTime);
        GetComponent<Image>().enabled = false;
        CurrentListItem.Instance.stockTransform.parent.gameObject.GetComponent<Image>().enabled = true;
    }
}
