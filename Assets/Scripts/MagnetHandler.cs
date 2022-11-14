using System.Collections;
using TMPro;
using UnityEngine;

public class MagnetHandler : MonoBehaviour
{
    [SerializeField] private Transform stocksHolder;
    [SerializeField] private float swapCd;
    [SerializeField] private LeanTweenType animCurve;

    private bool rearranging;
    private bool goingUp;
    private int currentHoldingsVal;
    private int index;
    private int prevIndex;

    private void Update()
    {
        if (rearranging) return;
        for (int i = 0; i < transform.childCount; i++)
        {
            stocksHolder.GetChild(i).transform.position = new Vector3(transform.GetChild(i).transform.position.x,transform.GetChild(i).transform.position.y,0f);
        }
    }

    public void CallListItem(int i)
    {
        index = i;
        Debug.Log(index);
        stocksHolder.GetChild(i).gameObject.GetComponent<ListItemHandler>().OnListItemClick();
    }

    public void Sort(bool add, int holdings)
    {
        goingUp = add;
        currentHoldingsVal = holdings;
        rearranging = true;
        if (CheckIfSorted()) return;
        Swap();
    }

    private void Swap()
    {
        LeanTween.move(stocksHolder.GetChild(prevIndex).gameObject, transform.GetChild(index).position, swapCd).setEase(animCurve);
        LeanTween.move(stocksHolder.GetChild(index).gameObject, transform.GetChild(prevIndex).position, swapCd).setEase(animCurve);
        stocksHolder.GetChild(prevIndex).SetSiblingIndex(index);
        StartCoroutine(SwapCooldown(swapCd));
    }

    private IEnumerator SwapCooldown(float time)
    {
        if (CheckIfSorted())
        {
            rearranging = false;
            index = prevIndex;
        }
        
        else
        {
            yield return new WaitForSeconds(time);
            Swap();
        }
    }

    private bool CheckIfSorted()
    {
        Debug.Log(index);
        prevIndex = index;
        index = goingUp ? index - 1 : index + 1;
        if (index < 0 )
        {
            index = 0;
            return true;
        }
        if (index >= stocksHolder.childCount)
        {
            index = stocksHolder.childCount - 1;
            return true;
        }
        
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
