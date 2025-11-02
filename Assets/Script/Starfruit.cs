using UnityEngine;

public class Starfruit : Crop
{
    [SerializeField]
    Material materialSad;
    [SerializeField]
    Material materialSpicy;

    [SerializeField]
    GameObject spicyVFX;

    public enum EffectLevel
    {
        Sad,
        Spicy
    }

    private EffectLevel effect;

    private void Start()
    {
        //Set spicy or not at spawn time (presumably starts spicy, since things only grow during sunny.
        OnWeatherUpdate();

        
        Weather._instance.WeatherChangeUpdate += OnWeatherUpdate;

    }


    public void OnWeatherUpdate()
    {
        //Debug.Log("WeatherUpdate_Starfruit");
        switch (Weather._instance.currentWeather)
        {
            case Weather.WeatherState.Sunny:
                effect = EffectLevel.Spicy;
                gameObject.GetComponentInChildren<Renderer>().material = materialSpicy;
                break;
            default:
                effect = EffectLevel.Sad;
                gameObject.GetComponentInChildren<Renderer>().material = materialSad;
                break;
        }
    }

    protected override void PlayerCollect(GameObject player)
    {
        Weather._instance.WeatherChangeUpdate -= OnWeatherUpdate;
        GetComponent<Collider>().isTrigger = true;
        GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 10.0f, 1.0f), ForceMode.Impulse);
        if (effect == EffectLevel.Spicy)
        {
            GameObject vfxRef = Instantiate(spicyVFX, player.transform);
            player.GetComponent<PlayerController>().speed *= 1.5f;
            player.GetComponent<Renderer>().material = materialSpicy;
        }
        Destroy(this.gameObject, 2.0f);
    }
}
