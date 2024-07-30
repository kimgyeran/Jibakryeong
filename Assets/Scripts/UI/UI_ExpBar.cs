using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class UI_ExpBar : MonoBehaviour
{ 
    GameObject progressBar;
    RectTransform pBarRect;
    int maxProg = 100;
    int nowProg = 0;
    void Start()
    {
        
        progressBar = transform.GetChild(0).gameObject;
        pBarRect = progressBar.GetComponent<RectTransform>();
        adjustProgressBar();
    }
    public void SetMaxExp(int max)
    {
        maxProg = max;
        adjustProgressBar();
    }

    public void SetExpValue(int exp)
    {
        if (exp > maxProg) return;
        nowProg = exp;
        adjustProgressBar();
    }

    private void adjustProgressBar()
    {
        pBarRect.localScale = new Vector3((float)nowProg / (float)maxProg, 1f);
    }
    private void Update()
    {
        SetExpValue(Mathf.FloorToInt(GameManager.Instance.Player.EXPPercent));
    }

}
