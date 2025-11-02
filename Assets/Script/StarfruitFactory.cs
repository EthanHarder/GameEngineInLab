using UnityEngine;

public class StarfruitFactory : CropFactory
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public override void SpawnCrop(Vector3 position)
    {
        GameObject newCrop = Instantiate(crop, position, Quaternion.identity);

        
    }

    public override void LaunchCrop(GameObject crop)
    {
        crop.GetComponent<Rigidbody>().AddForce(new Vector3(5.0f * Random.Range(-1.0f, 1.0f), 20.0f * Random.Range(-1.0f, 1.0f), 5.0f * Random.Range(-1.0f, 1.0f)), ForceMode.Impulse);
    }
}
