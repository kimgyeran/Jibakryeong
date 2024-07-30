using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PeopleAI : MonoBehaviour
{
    public GameObject Target;
    People people;
    NavMeshAgent agent;
    Animator anim;
    float surprised_time;
    Vector3 runaway_des;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        people = GetComponent<People>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Target.transform.position);
        agent.stoppingDistance = 3f;
        agent.updateRotation = false;
        agent.acceleration = 1f;
        agent.speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (people.is_Runaway)
        {
            anim.SetFloat("Move", 2f);
            RunawayUpdate();
            return;
        }
        Vector2 forward = new Vector2(transform.position.z, transform.position.x);
        Vector2 steeringTarget = new Vector2(agent.steeringTarget.z, agent.steeringTarget.x);

        //방향을 구한 뒤, 역함수로 각을 구한다.
        Vector2 dir = steeringTarget - forward;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //방향 적용
        transform.eulerAngles = Vector3.up * angle;

        anim.SetFloat("Move", agent.velocity.magnitude);
    }
    public void Hit(float damage)
    {
        if (people.is_Runaway)
            return;
        people.HP -= damage;
        if (people.HP <= 0)
        {
            people.is_Runaway = true;
            RunawayStart();
        }
    }
    public void Surprised(float time)
    {
        if (people.is_Runaway)
        {
            StopCoroutine(ISurprised());
            return;
        }

        if (surprised_time < time)
        {
            surprised_time = time;
        }
        StartCoroutine(ISurprised());
    }
    IEnumerator ISurprised()
    {
        agent.isStopped = true;
        while (surprised_time > 0)
        {
            yield return null;
            surprised_time -= Time.deltaTime;
        }
        agent.isStopped = false;

    }
    public void RunawayStart()
    {
        runaway_des = transform.position - Target.transform.position;
        runaway_des.y = 0;
        runaway_des.Normalize();
        transform.LookAt(transform.position + runaway_des);
        gameObject.GetComponent<Collider>().enabled = false;
        agent.enabled = false;
        people.is_Runaway = true;
        GameManager.Instance.PeopleRunEvent.Invoke(people.EXP);
        GameObject.Destroy(gameObject, 3f);
    }
    void RunawayUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * people.Speed);
    }
}
