using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public PeopleFactory people = new PeopleFactory();
    public static GameManager Instance
    {
        get
        {
            
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    public UnityEvent<int,int?> UpgradeEvent;
    public UnityEvent<int> AddSkillEvent;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }


}
