using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SortinZ : MonoBehaviour
{

    public void Awake()
    {
        UpdateView();
    }

    private void FixedUpdate()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if(sr != null)
        {
            sr.sortingOrder = (int)(transform.position.z * -1000);
        }
        else
        {
            SortingGroup sg = GetComponent<SortingGroup>();
            if(sg != null)
            {
                sg.sortingOrder = (int)(transform.position.z * -1000);
            }
        }
    }
}
