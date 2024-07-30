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
    public float MaxDistance = 500f;
    public float WarningDistance = 400f;
    public float Distance;
    public GameObject Center;

    [HideInInspector]
    public UnityEvent<int,int?> UpgradeEvent;
    [HideInInspector]
    public UnityEvent<int> AddSkillEvent;
    [HideInInspector]
    public UnityEvent<int> PeopleRunEvent;
    [HideInInspector]
    public UnityEvent WarnnigEvent;

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
    private void Update()
    {
        CalcDistance();
        if (Distance > WarningDistance)
        {
            WarnnigEvent.Invoke();
        }
        if(Distance>MaxDistance)
        {
            GameOver();
        }
    }
    void CalcDistance()
    {
        Distance = (Center.transform.position - Player.transform.position).magnitude;
    }
    void GameOver()
    {

    }
}
