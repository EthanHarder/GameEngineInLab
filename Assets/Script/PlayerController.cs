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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public TMP_Text SeedText;
    // Update is called once per frame
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

            UpdateSeedText();
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

    //Updates screen UI.
    void UpdateSeedText()
    {
        if (SeedText != null)
        {
            SeedText.text = System.Enum.GetName(typeof(CropSpawner.PlantType), currentSeeds);
        }
    }
}
