using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public ObstacleManager manager;

    [SerializeField]
    public float speedRequirement;

    protected virtual void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Wall touch");
        if (collisionInfo.gameObject.tag == "Player")
        {
            if (collisionInfo.gameObject.GetComponent<PlayerController>().speed >= speedRequirement)
            {
                manager.BreakObstacle(this);
            }
        }
    }
}
