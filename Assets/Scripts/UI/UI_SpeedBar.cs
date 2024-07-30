using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class UI_SpeedBar : MonoBehaviour
{ 
    GameObject progressBar;
    RectTransform pBarRect;
    float maxProg = 100;
    float nowProg = 0;
    void Start()
    {
        progressBar = transform.GetChild(0).gameObject;
        pBarRect = progressBar.GetComponent<RectTransform>();
        adjustProgressBar();
    }
    public void SetMaxExp(float max)
    {
        maxProg = max;
        adjustProgressBar();
    }

    public void SetExpValue(float exp)
    {
        if (exp > maxProg) return;
        nowProg = exp;
        adjustProgressBar();
    }

    private void adjustProgressBar()
    {
        pBarRect.localScale = new Vector3(nowProg / maxProg, 1f);
    }


}
