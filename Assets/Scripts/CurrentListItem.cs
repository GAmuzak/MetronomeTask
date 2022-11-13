using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentListItem : MonoBehaviour
{
    private static CurrentListItem _instance;
    
    public string stockType;
    public int cost;
    public int multiplier;
    public int holdings;
    public Transform stockTransform;
    
    public static CurrentListItem Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<CurrentListItem>();
            if (_instance != null) return _instance;
            GameObject cli = new GameObject();
            cli.AddComponent<CurrentListItem>();
            return _instance;
        }
    }
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        _instance = this;
    }
    
    public void UpdateVisual()
    {
        string targetString = holdings.ToString();
        if (holdings < 10) targetString= "0" + targetString;
        stockTransform.GetChild(3).GetComponent<TextMeshProUGUI>().text = targetString;
    }
}

