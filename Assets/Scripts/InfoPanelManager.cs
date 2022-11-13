using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanelManager : MonoBehaviour
{
    [SerializeField] private List<Info> infoTypes;

    private void OnEnable()
    {
        ListItemHandler.OnStockClick += UpdateInfoPanel;
    }

    private void OnDisable()
    {
        ListItemHandler.OnStockClick -= UpdateInfoPanel;
    }

    private void UpdateInfoPanel()
    {
        foreach (Info infoType in infoTypes)
        {
            if (infoType.Title.Equals(CurrentListItem.Instance.stockType))
            {
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = infoType.Title;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = infoType.Content;
                break;
            }
        }
    }
}

[Serializable]
public class Info
{
    [SerializeField] private string title;
    [SerializeField][TextArea(3,5)] private string content;
    
    public string Title => title;
    public string Content => content;
}
