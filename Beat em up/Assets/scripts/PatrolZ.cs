using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolZ : MonoBehaviour
{
    public float speed;
   
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Tope"))
            speed *= -1;
    }
}
