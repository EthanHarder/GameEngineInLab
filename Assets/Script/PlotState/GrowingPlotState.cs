using UnityEngine;

public class GrowingPlotState : PlotState
{

    public GrowingPlotState(Plot plotRef) : base(plotRef) { }
    

    override public void PlotBehaviour(bool d)
    {
        //Growing does not care about the doTick bool.

        //Spend hydrated to get a random lesser amount of growth

        if (plotRef.plantType == CropSpawner.PlantType.None) return;

        if (plotRef.hydrated > 0.0f)
        {
            plotRef.hydrated -= Time.deltaTime;
            plotRef.growth += Time.deltaTime * UnityEngine.Random.Range(0.0f, 0.3f);
        }

        if (plotRef.growth >= 1.0f)
        {
            plotRef.CropComplete();
        }
    }
}
