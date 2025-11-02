using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    

    //Water resource, gained by rain
    [SerializeField]
    public float hydrated;

    [SerializeField]
    public float hydrationMax;

    //progress to being fully grown
    public float growth = 0;


    //Random chance upper bound for checking if there is rain.
    [SerializeField]
    public int randomTickUpper;

    [SerializeField]
    public Material dirt_dry;

    [SerializeField]
    public Material dirt_wet;


    public GameObject plant;

    public CropSpawner.PlantType plantType;

    [SerializeField]
    private GameObject cropSpawnPoint;


    public PlotState state;


    void Start()
    {
        state = new WateringPlotState(this, 0.0f);
        Weather._instance.WeatherChangeUpdate += OnWeatherChange;
    }

    // Update is called once per frame
    void Update()
    {
        //There is a 1 in randomTickUpper chance that 
        bool doTick = (UnityEngine.Random.Range(0, randomTickUpper) == 0);
            state.PlotBehaviour(doTick);
        

        UpdateVisuals();
    }


    public void OnWeatherChange()
    {
        state.Transition(Weather._instance.currentWeather);
    }

    public void UpdateVisuals()
    {

        
        if (hydrated > 0.0f)
        {

            GetComponent<Renderer>().material = dirt_wet;
        }
        else
        {
            GetComponent<Renderer>().material = dirt_dry;
        }

        //Grow plant based on growth variable
        plant.transform.localScale = new Vector3(growth,growth,growth);

    }


    public void NewPlant(CropSpawner.PlantType plantType)
    {
        plant.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        this.plantType = plantType;
    }

    public void CropComplete()
    {
        growth = 0.0f;
        CropSpawner._instance.SpawnCrop(plantType, cropSpawnPoint.transform.position);

        plant.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        plantType = CropSpawner.PlantType.None;
    }
}
