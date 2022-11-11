using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter3D : MonoBehaviour
{
    public int NextScene;
    public GameObject Spawner;
    public Camera MainCamera;
    private void Start()
    {
        Spawner.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("NextLvl"))
        {
            NextLevel();
        }
        if(collision.gameObject.CompareTag("StartSpawner"))
        {
            Spawner.SetActive(true);
            MainCamera.GetComponent<FollowCamera>().ChangeSpeed(0f);
            Destroy(collision.gameObject);
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
