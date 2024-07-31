using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_LevelUpCardWrapper : MonoBehaviour
{
    public static UI_LevelUpCardWrapper instance;
    public List<LevelUpEventData> eventDataList = new List<LevelUpEventData>();
    public UI_LevelUpCardController[] LevelUpCardArr = new UI_LevelUpCardController[3];
    bool isUnlocked = false;

    public void SetRandomCard()
    {
        for (int i = 0; i < 3; i++)
        {
            LevelUpCardArr[i].gameObject.SetActive(true);
        }
        int min = 1;
        if (!isUnlocked)
        {
            min = 0;
        }

        int[] nowList = new int[3];
        for (int i = 0; i < 3; i++)
        {
            int temp = UnityEngine.Random.Range(min, eventDataList.Count);
            bool endTrigger = false;
            for (int j = 0; j < i; j++)
            {
                if (temp == nowList[j])
                {
                    endTrigger = true; break;
                }
            }
            if (endTrigger)
            {
                i--; continue;
            }
            nowList[i] = temp;
        }


        for (int i = 0; i < 3; i++)
        {
            LevelUpCardArr[i].data = eventDataList[nowList[i]];
            LevelUpCardArr[i].applyData();
        }

    }

    public void OnCardSelected(LevelUpEventData eventData)
    {
        if(eventData.EventId == 0)
        {
            isUnlocked = true;
            GameManager.Instance.AddSkillEvent.Invoke(0);
        }
        GameManager.Instance.UpgradeEvent.Invoke(eventData.EventId, eventData.Impact);

        for (int i = 0; i < 3; i++)
        {
            LevelUpCardArr[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            LevelUpCardArr[i] = transform.GetChild(i).gameObject.GetComponent<UI_LevelUpCardController>();
        }
        UI_LevelUpCardController.wrapper = this;
        if(instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < 3; i++)
        {
            LevelUpCardArr[i].gameObject.SetActive(false);
        }
    }
}
