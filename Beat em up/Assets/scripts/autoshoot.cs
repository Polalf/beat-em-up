using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoshoot : MonoBehaviour
{
    public Animator animatorShooter;
    public float range;
    private float distpl;
    public Transform player, Shootpos;

    public GameObject Bullet;

    public float coldDown;
    private float timershoot = 0f;
    private bool canShoot = false;

    public float ShootCount;


    // Update is called once per frame
    void Update()
    {
        distpl = Vector2.Distance(transform.position, player.position);
        if (distpl <= range && canShoot)
        {
            Shoot();
            canShoot = false;
            timershoot = 0;

        }
       
        if (timershoot >= coldDown)
        {

            canShoot = true;
        }
        else
        {
            timershoot += Time.deltaTime;
        }
        
       
    }
    private void Shoot()
    {
       
        animatorShooter.SetTrigger("ATK");


        GameObject bullet = Instantiate(Bullet, Shootpos.position, Shootpos.rotation);
    }
}
