using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PeopleFactory 
{
    public PeopleFactory()
    {
        levelArt = GameObject.Find("levelArt");
        StartStage();
    }
    static int[] stageTable = new int[5] {10,13,15,17,19};
    public GameObject people;
    public GameObject levelArt;
    static int nowStage = 1;
    static int nowPeople = 0; 
    
    public void StartStage()
    {
        init();
        nowPeople = stageTable[nowStage - 1];
        left.SetEnemyCount(nowPeople);
        InstantiatePeople(nowPeople);
    }

    public void OnPeopleDead()
    {
        nowPeople--;
        left.SetEnemyCount(nowPeople);
        if (nowPeople == 0)
        {
            nowStage++;
            StartStage();
        }

    }
    private void InstantiatePeople(int peopleCount)
    {
        for (int i = 0; i < peopleCount; i++)
        {
            GameObject.Instantiate(people, levelArt.transform.position + GetRandomPosition(), people.transform.rotation);
        }
    }
    int offset = 10;
    private Vector3 GetRandomPosition()
    {
        int diffX = Random.Range(2, offset);
        int diffY= Random.Range(2, offset);
        return new Vector3(diffX, 3 ,diffY);
    }


    static UI_LeftEnemyCount left = null;
    private static void init()
    {
        if(left == null)
        {
            left = (UI_LeftEnemyCount)UIManager.GetUI(UIManager.UIElement.LeftEnemyCount);
        }
    }



}
