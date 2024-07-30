using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class UI_NowLevel : MonoBehaviour
{
    Text text;
    public void Start()
    {
        text = transform.GetChild(0).gameObject.GetComponent<Text>();
    }
    public void SetLevel(int level)
    {
        text.text = $"Level {level}";
    }
}
