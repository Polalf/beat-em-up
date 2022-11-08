using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    public Animator EnemyAnimator;

    [Header("Life")]
    public int maxLife;
    public int currentLife;

    [Header("Look At")]
    public GameObject target;
    public float offset;

    [Header("Move")]
    private Rigidbody rb;
    public float speed;

    [Header("Attack")]
    public int EnemyDamage;
    public float ViewRange;
    public float coldown;
    private bool canAtk;
    float timerAtk = 0f;
    private float distpl;
    public Transform player;
    public Transform AtkPoint;
    public float AtkRange;
    public LayerMask PlayerLayer;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
         
        currentLife = maxLife;
        canAtk = true;
    }


    void Update()
    {

        //Look At
        transform.up = target.transform.position - transform.position;

        //Move
        
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        // Attack
        distpl = Vector2.Distance(transform.position, player.position);

        if (distpl <= ViewRange && canAtk)
        {
            Attack();
            canAtk = false;
            timerAtk = 0;

        }
        if(timerAtk >= coldown)
        {
            canAtk = true;
        }
        else
        {
            timerAtk += Time.deltaTime;
        }


        //if (currentLife <= 0)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    private void Attack()
    {
        EnemyAnimator.SetTrigger("ATKenemy");

        Collider[] hitPlayer = Physics.OverlapSphere(AtkPoint.position, AtkRange, PlayerLayer);

        foreach (Collider player in hitPlayer)
        {
            player.GetComponent<Player>().PlayerTakeDamage(EnemyDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (AtkPoint == null)
            return;
        Gizmos.DrawWireSphere(AtkPoint.position, AtkRange);
    }




    public void EnemyTakeDamage(int damage)
    {
        currentLife -= damage;
        
        if(currentLife <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("muelto");

    }
}
