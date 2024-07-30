using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamRange : MonoBehaviour
{
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var people = other.GetComponent<PeopleAI>();
        people.Hit(player.ScreamAttackDamage * GameManager.Instance.Distance/GameManager.Instance.MaxDistance);
    }
}
