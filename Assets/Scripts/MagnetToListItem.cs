using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetToListItem : MonoBehaviour
{
    public void OnMagnetClick()
    {
        transform.parent.gameObject.GetComponent<MagnetHandler>().CallListItem(transform.GetSiblingIndex());
    }
}
