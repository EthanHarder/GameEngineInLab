using UnityEngine;

public class WateringPlotState : PlotState
{

    private float wateringMag;
    public WateringPlotState(Plot plotRef, float wateringMag) : base(plotRef)
    {
        this.wateringMag = wateringMag;

    }

    override public void PlotBehaviour(bool d)
    {
        if (!d) return;
        plotRef.hydrated += 1.0f * wateringMag;
        if (plotRef.hydrated > plotRef.hydrationMax)
        {
            plotRef.hydrated = plotRef.hydrationMax;
        }
    }
}
