using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_AlertDistance : MonoBehaviour
{
    Coroutine Alert = null;
    public void SetOnAlert()
    {
        if (Alert == null)
        {
            Alert = StartCoroutine("OnBlink");
        }
    }
    public void SetOffAlert()
    {
        if (Alert != null)
        {
            StopCoroutine("OnBlink");
            image.color = invisible;
            Alert = null;
        }
    }


    Image image;
    readonly Color invisible = new Color(1,1,1, 0);
    readonly Color barely = new Color(1, 1, 1, 0.35f);
    readonly Color slightly = new Color(1, 1, 1, 0.7f);
    void Start()
    {
        image = GetComponent<Image>();
        image.color = invisible;
        SetOnAlert();
    }

    float offset = 0.5f;
    bool isBarely = true;
    IEnumerator OnBlink()
    {
        while(true)
        {
            if(isBarely)
            {
                isBarely = false; 
                image.color = slightly;
            }
            else
            {
                isBarely = true; 
                image.color = barely;
            }
            yield return new WaitForSeconds(offset);
        }
    }

}
