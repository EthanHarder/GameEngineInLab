using System;
using UnityEngine;
using static Weather;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public float speed;

    [SerializeField]
    LayerMask plotMask;

    [SerializeField]
    CropSpawner.PlantType currentSeeds;
    public delegate void Notify(CropSpawner.PlantType newSeeds);
    public event Notify SeedChange;

    void Update()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.transform.position += moveVec * speed * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.E))
        {
            int length = Enum.GetValues(typeof(CropSpawner.PlantType)).Length;
            int seedIndex = (int)currentSeeds;
            seedIndex++;
            if (seedIndex > length - 1)
            seedIndex = 0;
            

            currentSeeds = (CropSpawner.PlantType)seedIndex;

            SeedChange?.Invoke(currentSeeds);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Attempting Raycast");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, plotMask, QueryTriggerInteraction.Collide))
            {
                Debug.Log("Raycast hit");
                hit.transform.GetComponent<Plot>().NewPlant(currentSeeds);
            }
        }




    }
}
