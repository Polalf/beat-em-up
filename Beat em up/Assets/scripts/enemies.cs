using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    [Header("Life")]
    public int maxLife;
    public int currentLife;
    [Header("Move")]
    [Header("Attack")]
    public float range;
    private float distpl;
    public Transform player;
    void Start()
    {

    }


    void Update()
    {
        distpl = Vector2.Distance(transform.position, player.position);
        if(distpl<=range)
        {

        }
        if (currentLife <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
