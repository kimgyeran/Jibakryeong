using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Skill : MonoBehaviour
{
    bool isReady = true;
    float coolDown = 5f;
    float offset = 0.05f;
    GameObject coolDownPanel;
    RectTransform coolDownPanelRect;
    void Start()
    {
        coolDownPanel = this.transform.GetChild(0).gameObject;
        coolDownPanelRect = coolDownPanel.GetComponent<RectTransform>();    
    }

    float nowCoolDown = 0;
    public void ActiveSkill(int _coolDown)
    {
        nowCoolDown = 0;
        coolDown = _coolDown;
        isReady = false; 
        StartCoroutine("CoolDown");
    }

    IEnumerator CoolDown()
    {
        while(true)
        {
            if(nowCoolDown < coolDown)
            { 
                nowCoolDown += offset;
                adjustCoolDownPanel();
            }
            else
            { 
                isReady = true;
                adjustCoolDownPanel();
                break;
            }
            yield return new WaitForSeconds(offset);
        }
    }
    private void adjustCoolDownPanel()
    {
        if(isReady)
        {
            coolDownPanelRect.localScale = new Vector2(1,0);
        }
        else
        {
            coolDownPanelRect.localScale = new Vector2(1, 1f / coolDown * (coolDown - nowCoolDown));
        }
    }

}
