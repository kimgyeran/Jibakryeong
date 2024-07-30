using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    
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
    [HideInInspector]
    public UnityEvent<int,int?> UpgradeEvent;
    [HideInInspector]
    public UnityEvent<int> AddSkillEvent;
    [HideInInspector]
    public UnityEvent<int> PeopleRunEvent;

    public PlayerController Player { get; private set; }
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
    private void Start()
    {
        Player = Player ?? GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

}
