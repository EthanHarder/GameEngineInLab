using NUnit.Framework;
using UnityEngine;

public abstract class CropFactory : MonoBehaviour
{

    [SerializeField]
    protected GameObject crop;


    public abstract void SpawnCrop(Vector3 position);

    public abstract void LaunchCrop(GameObject crop);

}
