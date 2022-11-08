using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Animator playerAnimator;

    [Header("Move")]
    public CharacterController controller;
    public float speed = 5f;
    private Vector3 playerVelocity;
    public float jumpForce = 10f;

    [Header("Life")]
    public int maxLife;
    public int currentLife;
    public GameObject gameOver;
    public HealthBar healthBar;

    [Header("Attack")]
    public KeyCode atkKey;
    public int Damage;
    public float coldown;
    private bool canAttack;
    float timeratk = 0f;
    public Transform attackpoint;
    public float AtkRange = 0.5f;
    public LayerMask enemyLayer;

    //public Transform 


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        currentLife = maxLife;
        healthBar.SetMaxHealth(maxLife);
        canAttack = true;
    }

    void Update()
    {
        //MOVE
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);
        if (Input.GetAxis("Horizontal") < -0.001f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        if (Input.GetAxis("Horizontal") > 0.001f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //LIFE
        if (currentLife <= 0)
        {
            gameObject.SetActive(true);

        }
        if(currentLife > maxLife)
        {
            currentLife = maxLife;
        }
        //attack
        if (timeratk >= coldown)
        {
            canAttack = true;
        }
        else
        {
            timeratk += Time.deltaTime;
        }
        if (Input.GetKeyDown(atkKey) && canAttack)
        {
            Attack();
            canAttack = false;
            timeratk = 0;
        }


    }
  
    void Attack()
    {
        playerAnimator.SetTrigger("ATK");

        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, AtkRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<enemies>().EnemyTakeDamage(Damage);
        }
    } 
    public void PlayerTakeDamage(int enemyDamage)
    {
        currentLife -= enemyDamage;

        if (currentLife <= 0)
        {
            //GameOver
            Debug.Log("GameOver");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, AtkRange);
    }
    



}
 