using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transports : MonoBehaviour
{
    public Vector3 puntB;
    
    void Update()
    {
        
    }
    private void OnTriggerEnter2d(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Entrada"))
        {
            transform.position = new Vector3(puntB);
        }
    }
}
