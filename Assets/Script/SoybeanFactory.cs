using UnityEngine;

public class SoybeanFactory : CropFactory
{
 


    public override void SpawnCrop(Vector3 position)
    {
        Instantiate(crop, position, Quaternion.identity);

        LaunchCrop(crop);
    }

    public override void LaunchCrop(GameObject crop)
    {
        crop.GetComponent<Rigidbody>().AddForce(new Vector3(5.0f * Random.Range(-1.0f, 1.0f), 5.0f * Random.Range(-1.0f, 1.0f), 5.0f * Random.Range(-1.0f, 1.0f)), ForceMode.Impulse);
    }
}
