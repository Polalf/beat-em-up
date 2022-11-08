using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public float Coldown;
    float timerSpawn = 0f;
    bool canSpawn = true;
    public Transform SpawnerPos;
    public int MaxSpawn;
    private int Spawns = 0;
           
    void Start ()
    {
        Spawns = 0;
    }

    void Update()
    {
        if (Spawns < MaxSpawn)
        {
            if (canSpawn)
            {
                Spawn();
                timerSpawn = 0;
                canSpawn = false;
                Spawns++;


            }
            if (timerSpawn >= Coldown)
            {
                canSpawn = true;
            }
            else
            {
                timerSpawn += Time.deltaTime;
            }
        }
    }
    private void Spawn()
    {
        GameObject enemy = Instantiate(Enemy, SpawnerPos.position, SpawnerPos.rotation); 
    }

}
