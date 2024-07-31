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
        while (true)
        {
            if (nowCoolDown < coolDown)
            {
                nowCoolDown += offset;
                adjustCoolDownPanel(nowCoolDown);
            }
            else
            {
                isReady = true;
                adjustCoolDownPanel(nowCoolDown);
                break;
            }
            yield return new WaitForSeconds(offset);
        }
    }
    public void adjustCoolDownPanel(float _now_cooldown)
    {

        coolDownPanelRect.localScale = new Vector2(1, 1f / coolDown * (_now_cooldown));

    }

}
