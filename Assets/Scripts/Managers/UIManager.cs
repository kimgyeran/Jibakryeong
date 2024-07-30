using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIManager
{
    public enum UIElement
    {
        Skill_Attack, Skill_Scream,
        ExpBar, NowLevel, LeftEnemyCount, AlertDistance, SpeedBar,
        LevelUpSelection
    }
    /// <summary>
    /// UIElement Enum에 해당하는 스크립트를 가져옵니다.
    /// 즉 Skill_Attack의 경우 (UI_Skill)GetUI(UIElement.Skill_Attack) 과 같이 변환을 해야합니다.
    /// </summary>
    /// <param name="ele"></param>
    /// <returns></returns>
    public static object GetUI(UIElement ele)
    {
        init();
        return dict[ele].Item2;
    }

    private static GameObject canvas;
    private static Dictionary<UIElement,(GameObject,object)> dict = new Dictionary<UIElement, (GameObject, object)>();
    
    private static void init()
    {
        if(canvas == null)
        {
            GameObject temp = (GameObject)Resources.Load("UI/Prefabs/UI_InGameCanvas");
            if(temp == null)
            {
                Debug.Log("Error : Unvalid Path UI/Prefabs/UI_InGameCanvas.");
                return;
            }
            canvas = GameObject.Instantiate(temp);

            GameObject skill_Attack = canvas.transform.Find("UI_Skill_Attack").gameObject;
            dict.Add(UIElement.Skill_Attack, (skill_Attack, skill_Attack.GetComponent<UI_Skill>()));

            GameObject skill_Scream = canvas.transform.Find("UI_Skill_Scream").gameObject;
            dict.Add(UIElement.Skill_Scream, (skill_Scream, skill_Scream.GetComponent<UI_Skill>()));

            GameObject nowLevel = canvas.transform.Find("UI_NowLevel").gameObject;
            dict.Add(UIElement.NowLevel, (nowLevel, nowLevel.GetComponent<UI_NowLevel>()));

            GameObject expBar = canvas.transform.Find("UI_ExpBar").gameObject;
            dict.Add(UIElement.ExpBar, (expBar, expBar.GetComponent<UI_ExpBar>()));

            GameObject leftCount = canvas.transform.Find("UI_LeftEnemyCount").gameObject;
            dict.Add(UIElement.LeftEnemyCount, (leftCount, leftCount.GetComponent<UI_LeftEnemyCount>()));

            GameObject alertDistance = canvas.transform.Find("UI_AlertDistance").gameObject;
            dict.Add(UIElement.AlertDistance, (alertDistance, alertDistance.GetComponent<UI_AlertDistance>()));

            GameObject speedBar = canvas.transform.Find("UI_SpeedBar").gameObject;
            dict.Add(UIElement.SpeedBar, (speedBar, speedBar.GetComponent<UI_SpeedBar>()));
            
        }
    }
}
