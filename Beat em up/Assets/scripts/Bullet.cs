using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform AtkPoint;
    public float AtkRange;
    public LayerMask PlayerLayer;
    public GameObject hitEffect;
    public int damage = 5;
    public float speed = 5f;
    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        
        Collider[] hitPlayer = Physics.OverlapSphere(AtkPoint.position, AtkRange, PlayerLayer);

        foreach (Collider player in hitPlayer)
        {
            player.GetComponent<Player>().PlayerTakeDamage(damage);
        }
        Destroy(gameObject);
        
    }
    private void OnDrawGizmosSelected()
    {
        if (AtkPoint == null)
            return;
        Gizmos.DrawWireSphere(AtkPoint.position, AtkRange);
    }
}
