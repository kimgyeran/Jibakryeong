using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class UI_SpeedBar : MonoBehaviour
{
    GameManager manager;
    PlayerController pc;
    Text text;
    public void Start()
    {
        text = transform.GetChild(1).gameObject.GetComponent<Text>();
        manager = GameManager.Instance;
    }
    public void SetSpeed(int speed)
    {
        text.text = speed.ToString();
    }

    private void Update()
    {
        
    }
}


