

using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Player;

    public float Speed;
    public float CurrentSpeed;
    public int EnemiesIn;
    


    private void Start()
    {
        CurrentSpeed = Speed;
        Player.gameObject.GetComponent<Enter3D>().AddSpeed(Speed);
    }
    public void ChangeSpeed(float NewSpeed)
    {
        CurrentSpeed = NewSpeed;
    }
    void LateUpdate()
    {
        Vector3 Pos = new Vector3(Player.position.x, 0, -10);
        transform.position = Vector3.Slerp(transform.position, Pos, CurrentSpeed * Time.deltaTime);
    }
    public void EnemiesCount(int NewCount)
    {
        EnemiesIn = NewCount;
        Debug.Log(EnemiesIn);
        
        
    }
    public void EnemiesDead(int Deads)
    {
        EnemiesIn -= Deads;
        if (EnemiesIn <= 0)
        {
            CurrentSpeed = Speed;
        }
    }
}
