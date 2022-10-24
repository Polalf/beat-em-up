using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTP : MonoBehaviour
{
    private GameObject currentTP;

    public KeyCode EnterKey;
    
    void Update()
    {
        if (Input.GetKeyDown(EnterKey))
        {
            if (currentTP != null)
            {
                transform.position = currentTP.GetComponent<Teleporter>().GetDest().position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Entrada"))
        {
            currentTP = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Entrada"))
        {
            if (collision.gameObject == currentTP)
            {
                currentTP = null;
            }
        }
    }
}
