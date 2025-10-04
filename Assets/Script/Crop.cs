using UnityEngine;

public abstract class Crop : MonoBehaviour
{

    protected virtual void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            PlayerCollect(collisionInfo.gameObject);
        }
    }
    protected virtual void PlayerCollect(GameObject player)
    {
        Destroy(this.gameObject);
    }



}
