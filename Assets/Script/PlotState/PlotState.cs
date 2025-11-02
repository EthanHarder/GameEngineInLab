using UnityEngine;

public abstract class PlotState : MonoBehaviour
{

    protected Plot plotRef;

    public PlotState(Plot plotRef)
    {
        this.plotRef = plotRef;
    }


    abstract public void PlotBehaviour(bool validTick);

    virtual public void Transition(Weather.WeatherState newWeather)
    {
        switch (newWeather)
        {
            case Weather.WeatherState.Snow:
                plotRef.state = new WateringPlotState(plotRef, 0.0f);
                break;
            case Weather.WeatherState.Rain:
                plotRef.state = new WateringPlotState(plotRef, 2.0f);
                break;
            case Weather.WeatherState.Storm:
                plotRef.state = new WateringPlotState(plotRef, 6.0f);
                break;
            case Weather.WeatherState.Sunny:
                plotRef.state = new GrowingPlotState(plotRef);
                break;
            default:
                plotRef.state = new GrowingPlotState(plotRef);
                break;

        }
    }
}
