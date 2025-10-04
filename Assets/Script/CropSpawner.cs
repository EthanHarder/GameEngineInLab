using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CropSpawner : MonoBehaviour
{

    public static CropSpawner _instance;


    public enum PlantType
    {
        None,
        Pineapple,
        Blueberries,
        Soybeans,

    }


    public List<CropFactory> cropFactories;

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

    public void SpawnCrop(PlantType type, Vector3 position)
    {
        cropFactories[(int)type].SpawnCrop(position);
    }

}
