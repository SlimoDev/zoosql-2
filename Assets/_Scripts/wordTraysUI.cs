using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordTraysUI : MonoBehaviour
{

    void Update()
    {
        if (this.transform.childCount > 0)
        {
            this.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
        }
        else
        {
            this.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(1347, 289);
        }
    }
}
