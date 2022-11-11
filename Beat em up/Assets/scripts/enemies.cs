using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    public Animator EnemyAnimator;

    [Header("Life")]
    public int maxLife;
    public int currentLife;
    public Camera MainCamera;

    [Header("Look At")]
    public Transform target;
    public float offset;
    public bool isStatic = false;

    [Header("Move")]
    private Rigidbody rb;
    public float speed;
    public float currentSpeed;

    [Header("Attack")]
    public int EnemyDamage;
    public float ViewRange;
    public float coldown;
    private bool canAtk;
    float timerAtk = 0f;
    private float distpl;
    public Transform AtkPoint;
    public float AtkRange;
    public LayerMask PlayerLayer;
    

    void Start()
    {
        currentSpeed = speed;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        MainCamera = Camera.current;

        

        rb = this.GetComponent<Rigidbody>();
         
        currentLife = maxLife;
        canAtk = true;

        
    }


    void Update()
    {
        
        //Look At
        Vector3 diff = target.transform.position - transform.position;
        transform.right = new Vector3(diff.x, transform.right.y, diff.z) * -1;
        if (isStatic)

        {

            transform.right = new Vector3(diff.x, transform.right.y, diff.z) * 0;
            speed = 0;
        }

        //Move
        if (distpl > ViewRange)
            EnemyAnimator.SetBool("POnRange", false);
       {
            if(speed != 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, currentSpeed * Time.deltaTime); 
                EnemyAnimator.SetBool("Move", true);

            }
            
           
            
       }

        // Attack
        distpl = Vector2.Distance(transform.position, target.position);
       
        if (distpl <= ViewRange)
        {
            EnemyAnimator.SetBool("POnRange", true);
            currentSpeed = 0;
            EnemyAnimator.SetBool("Move", false);

            if (canAtk) 
            {
                

                Attack();
                canAtk = false;
                timerAtk = 0;
            }

        }
        else
        {

            currentSpeed = speed;
           
        }

        if (timerAtk >= coldown)
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
        Destroy(gameObject);
        MainCamera.GetComponent<FollowCamera>().EnemiesDead(1);

    }
}
