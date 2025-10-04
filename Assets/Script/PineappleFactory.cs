using UnityEngine;

public class PineappleFactory : CropFactory
{


    [SerializeField]
    private float sizeMin;
    [SerializeField]
    private float sizeMax;

    public override void SpawnCrop(Vector3 position)
    {
        GameObject newCrop = Instantiate(crop, position, Quaternion.identity);

        crop.transform.localScale = crop.transform.localScale * Random.Range(sizeMin, sizeMax);

        LaunchCrop(newCrop);
    }

    public override void LaunchCrop(GameObject crop)
    {
        crop.GetComponent<Rigidbody>().AddForce(new Vector3(5.0f * Random.Range(-1.0f, 1.0f), 20.0f * Random.Range(-1.0f, 1.0f), 5.0f * Random.Range(-1.0f, 1.0f)), ForceMode.Impulse);
    }
}
