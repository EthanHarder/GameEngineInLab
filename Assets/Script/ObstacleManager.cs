using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager _instance;

    [SerializeField]
    List<Obstacle> obstacles;

    public delegate void Notify(float score);
    public event Notify ObstacleDestroyed;

    public float obstacleScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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

        foreach (var obstacle in obstacles)
        {
            obstacle.manager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BreakObstacle(Obstacle o)
    {
        obstacleScore++;
        obstacles.Remove(o);

        Destroy(o.gameObject);

        ObstacleDestroyed?.Invoke(obstacleScore);
    }



}
