
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2f;
    public float Sensitivity = 1f;
    public float ScrollSensitivity = 1f;

    public GameObject ScreamRange;
    public float ScreamRangeRadius = 2f;
    public float ScreamCooldown = 1f;
    public float ScreamAttackDamage = 10f;

    public GameObject SurpriseRange;
    public float SurpriseRangeRadius = 2f;
    public float SurpriseCooldown = 3f;
    public float SurpriseAttackDamage = 10f;
    public float SurpriseDuration = 1f;

    private Animator Anim;

    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
    private static readonly int SurprisedState = Animator.StringToHash("Base Layer.surprised");
    private static readonly int AttackState = Animator.StringToHash("Base Layer.attack_shift");



    Vector3 r_dir;
    float r_speed;
    float scream_cooldown_remain = 0;
    float surprise_cooldown_remain = 0;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(RandomMoveCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        RandomMove();
        ChangeSpeed();
        Rotate();
        Move();
        Scream();
        Surprise();
    }
    void Rotate()
    {
        var dx = transform.localRotation.eulerAngles.x - Input.GetAxis("Mouse Y") * Sensitivity;
        var dy = transform.localRotation.eulerAngles.y + Input.GetAxis("Mouse X") * Sensitivity;
        transform.localRotation = Quaternion.Euler(dx, dy, 0);

    }
    void Move()
    {
        var dx = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        var dz = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        Anim.SetBool("Move", (dx != 0 || dz != 0));
        transform.Translate(new Vector3(dx, 0f, dz));
    }
    void ChangeSpeed()
    {
        Speed += Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;
    }
    void Scream()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (scream_cooldown_remain > 0)
                return;

            scream_cooldown_remain = ScreamCooldown;
            Anim.SetTrigger("Scream");
            ScreamRange.GetComponent<Collider>().enabled = true;
            StartCoroutine(IScreamAttackCooldown(ScreamRange.GetComponent<Collider>()));
        }
    }
    void Surprise()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (surprise_cooldown_remain > 0) return;

            surprise_cooldown_remain = SurpriseCooldown;
            Anim.SetTrigger("Surprised");
            SurpriseRange.GetComponent<Collider>().enabled = true;
            StartCoroutine(ISurpriseAttackCooldown(SurpriseRange.GetComponent<Collider>()));
        }
    }
    void RandomMove()
    {
        transform.position += r_speed * Time.deltaTime * r_dir;
    }
    IEnumerator RandomMoveCoroutine()
    {
        while (true)
        {
            r_dir = Random.insideUnitSphere;
            r_speed = Random.Range(0f, 0f);
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator IScreamAttackCooldown(Collider col)
    {
        var time = 0;
        
        while (scream_cooldown_remain > 0)
        {
            yield return null;
            scream_cooldown_remain -= Time.deltaTime;
            time++;
            if (time == 5 && col.enabled)
                col.enabled = false;
        }
        if (col.enabled)
            col.enabled = false;
    }
    IEnumerator ISurpriseAttackCooldown(Collider col)
    {
        var time = 0;
        while (surprise_cooldown_remain > 0)
        {
            yield return null;
            surprise_cooldown_remain -= Time.deltaTime;
            time++;
            if (time == 5 && col.enabled)
                col.enabled = false;
        }
        if (col.enabled)
            col.enabled = false;
    }
    public void Upgrade()
    {

    }
}
