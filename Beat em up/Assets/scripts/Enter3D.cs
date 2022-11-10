using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter3D : MonoBehaviour
{
    public int NextScene;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("NextLvl"))
        {
            NextLevel();
        }
        
        
    }
   private void NextLevel()
    {
        SceneManager.LoadScene(NextScene);
        ChangeTime(1);
    }
    public void ChangeTime(float newTime)
    {
        Time.timeScale = newTime;
    }
    void Update()
    {
        
    }
}
