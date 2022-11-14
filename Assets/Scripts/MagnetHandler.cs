using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MagnetHandler : MonoBehaviour
{
    [SerializeField] private Transform stocksHolder;
    [SerializeField] private float swapCd;
    [SerializeField] private LeanTweenType animCurve;

    private bool rearranging = true;
    private bool sortingNotComplete;
    private bool goingUp;
    private int currentHoldingsVal;
    private int index;
    private int prevIndex;

    private void Update()
    {
        if (!rearranging) return;
        for (int i = 0; i < transform.childCount; i++)
        {
            stocksHolder.GetChild(i).transform.position = new Vector3(transform.GetChild(i).transform.position.x,transform.GetChild(i).transform.position.y,0f);
        }
    }

    public void CallListItem(int i)
    {
        index = i;
        stocksHolder.GetChild(i).gameObject.GetComponent<ListItemHandler>().OnListItemClick();
    }

    public void Sort(bool add, int holdings)
    {
        goingUp = add;
        currentHoldingsVal = holdings;
        rearranging = false;
        if (CheckIfSorted()) return;
        Swap();
    }

    private void Swap()
    {
        LeanTween.move(stocksHolder.GetChild(prevIndex).gameObject, transform.GetChild(index).position, swapCd).setEase(animCurve);
        stocksHolder.GetChild(prevIndex).SetSiblingIndex(index);
        StartCoroutine(SwapCooldown(swapCd));
    }

    private IEnumerator SwapCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        rearranging = true;
        if (CheckIfSorted()) sortingNotComplete = false;
        else
        {
            Swap();
        }
    }

    private bool CheckIfSorted()
    {
        prevIndex = index;
        index = goingUp ? index - 1 : index + 1;
        if (index < 0 || index >= stocksHolder.childCount) return true;
        int nextHoldings = int.Parse(stocksHolder.GetChild(index).GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text);
        if (nextHoldings > currentHoldingsVal)
        {
            return goingUp;
        }
        if(nextHoldings < currentHoldingsVal)
        {
            return !goingUp;
        }
        return true;
    }
}
