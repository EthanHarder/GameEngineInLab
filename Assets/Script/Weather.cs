using System;
using UnityEngine;
using TMPro;

public class Weather : MonoBehaviour
{

    public static Weather _instance;


    public enum WeatherState
    {
        Sunny,
        Rain,
        Storm,
        Snow
    }


    public WeatherState currentWeather;
    //Used to determine the intended length of a weather event.
    [SerializeField]
    private float weatherDuration;

    //current weather timer
    private float currentDuration = 0;


    public TMP_Text weatherText;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }

    }

    void Update()
    {
        //Progress weather duration
        _instance.currentDuration -= Time.deltaTime;
        if (currentDuration <= 0.0)
        {
            NewWeatherCycle();
        }
    }

    void NewWeatherCycle()
    {
        //pick a random unique weather (no repeats).
        WeatherState oldWeather = currentWeather;
        while (oldWeather == currentWeather)
        {
            currentWeather = (WeatherState)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(WeatherState)).Length);
        }
       
        //Prepare weather to last expected duration
        currentDuration = weatherDuration;
        
        UpdateWeatherText(currentWeather);
        

    }

    //Updates screen UI.
    void UpdateWeatherText(WeatherState newWeather)
    {
        if (weatherText != null)
        {
            weatherText.text = System.Enum.GetName(typeof(WeatherState), newWeather);
        }
    }
}
