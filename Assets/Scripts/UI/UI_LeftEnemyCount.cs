using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LeftEnemyCount : MonoBehaviour
{
    Text text;
    public void Start()
    {
        text = transform.GetChild(0).gameObject.GetComponent<Text>();
    }
    public void SetEnemyCount(int level)
    {
        text.text = $"Left : {level}"; 
    }
}
