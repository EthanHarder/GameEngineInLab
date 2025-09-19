using UnityEngine;

public class Plot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //Water resource, gained by rain
    [SerializeField]
    public float hydrated;

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

    // Update is called once per frame
    void Update()
    {
        //Early termination (nothing grows if it is snowing)
        if (Weather._instance.currentWeather == Weather.WeatherState.Snow)
            return;

        //Check if sunny to grow.
       if (Weather._instance.currentWeather == Weather.WeatherState.Sunny && hydrated > 0.0f && growth <= 1)
       {
            //Spend hydrated to get a random lesser amount of growth
            hydrated -= Time.deltaTime;
            growth += Time.deltaTime * UnityEngine.Random.Range(0.0f, 0.3f);

            //confine growth, just in case that matters later.
            if (growth > 1.0f)
                growth = 1.0f;
        }


       //There is a 1 in randomTickUpper chance that 
       if (UnityEngine.Random.Range(0,randomTickUpper) == 0)
        {
            //if it is raining, add hydrated vaue.
            if (Weather._instance.currentWeather == Weather.WeatherState.Rain)
            {
                hydrated += 0.1f;
            }

            //Storm is rain on steroids.
            if (Weather._instance.currentWeather == Weather.WeatherState.Storm)
            {
                hydrated += 0.3f;
            }

        }


        UpdateVisuals();
    }

    void UpdateVisuals()
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
}
