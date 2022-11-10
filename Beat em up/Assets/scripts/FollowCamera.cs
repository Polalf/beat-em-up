
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Player; 

    public float Speed;
    
    void LateUpdate()
    {
        Vector3 Pos = new Vector3(Player.position.x, 0, -10);
        transform.position = Vector3.Slerp(transform.position, Pos, Speed * Time.deltaTime);
    }
}
