using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseRange : MonoBehaviour
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
        var peopleAI = other.GetComponent<PeopleAI>();
        peopleAI.Hit(player.SurpriseAttackDamage * GameManager.Instance.Distance / GameManager.Instance.MaxDistance);
        peopleAI.Surprised(player.SurpriseDuration);
    }
}
