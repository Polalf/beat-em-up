using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter3D : MonoBehaviour
{
    public int NextScene;
    public GameObject Spawner;
    public Camera MainCamera;
    public float SpeedCF;
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
        //if(collision.gameObject.CompareTag("FinalMapa"))
        //{
        //    MainCamera.GetComponent<FollowCamera>().ChangeSpeed(0f);
        //}
        
        


    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("FinalMapa"))
        {
            MainCamera.GetComponent<FollowCamera>().ChangeSpeed(0f);
        }
        if (collision.gameObject.CompareTag("inMap"))
        {
            MainCamera.GetComponent<FollowCamera>().ChangeSpeed(SpeedCF);
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
    public void AddSpeed(float newSpeed)
    {
        SpeedCF = newSpeed;
    }
}
