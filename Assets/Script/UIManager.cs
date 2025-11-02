using UnityEngine;
using TMPro;
using static Weather;

public class UIManager : MonoBehaviour
{


    [SerializeField]
    private TMP_Text SeedText;

    [SerializeField]
    private TMP_Text weatherText;


    [SerializeField]
    private TMP_Text obstacleScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Weather._instance.WeatherChangeUpdate += OnWeatherUpdate;

        ObstacleManager._instance.ObstacleDestroyed += OnObstacleBroken;
        GameObject.Find("Player").GetComponent<PlayerController>().SeedChange += OnSeedChoiceUpdate;
    }


    public void OnWeatherUpdate()
    {
        UpdateWeatherText();
    }

    public void OnSeedChoiceUpdate(CropSpawner.PlantType c)
    {
        UpdateSeedText(System.Enum.GetName(typeof(CropSpawner.PlantType), c));
    }

    public void OnObstacleBroken(float score)
    {
        obstacleScoreText.text = score.ToString();
    }

    void UpdateSeedText(string seedString)
    {
        if (SeedText != null)
        {
            SeedText.text = seedString;
        }
    }

    //Updates screen UI.
    void UpdateWeatherText()
    {
        if (weatherText != null)
        {
            weatherText.text = System.Enum.GetName(typeof(WeatherState), Weather._instance.currentWeather);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
