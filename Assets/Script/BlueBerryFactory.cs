using UnityEngine;

public class BlueBerryFactory : CropFactory
{

    [SerializeField]
    private float minCount;
    [SerializeField] 
    private float maxCount;


    public override void SpawnCrop(Vector3 position)
    {
        for (int i = 0; i < Random.Range(minCount, maxCount); i++)
        {
            GameObject newCrop = Instantiate(crop, position, Quaternion.identity);
            LaunchCrop(newCrop);
        }
    }

    public override void LaunchCrop(GameObject crop)
    {
        crop.GetComponent<Rigidbody>().AddForce(new Vector3(10.0f * Random.Range(-1.0f,1.0f) , 10.0f * Random.Range(-1.0f, 1.0f), 10.0f * Random.Range(-1.0f, 1.0f)), ForceMode.Impulse);
    }
}
