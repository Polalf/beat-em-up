using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        currentLife = maxLife;
        healthBar.SetMaxHealth(maxLife);
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
        if(currentLife<=0)
        {
            gameObject.SetActive(true);

        }
        //attack
        
       
    }
    

    

}
