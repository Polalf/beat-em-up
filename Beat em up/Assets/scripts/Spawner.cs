using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public float Coldown;
    float timerSpawn = 0f;
    bool canSpawn = true;
    public transform SpawnerPos;
           
    void Update()
    {
        if(canSpawn)
        {
            Spawn();
            timerSpawn = 0;
            canSpawn = false;
        }
        if(timerSpawn >= Coldown)
        {
            canSpawn = true;
        }
        else
        {
            timerSpawn += Time.deltaTime;
        }
    }
    private void Spawn()
    {
        GameObject enemy = Instatiate(Enemy, SpawnerPos.position, SpawnerPos.Rotation); 
    }

}
