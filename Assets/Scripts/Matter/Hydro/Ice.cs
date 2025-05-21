using UnityEngine;

public class Ice : StateOfMatter
{
    private Hydro hydro;
    internal Ice(Hydro hydro)
    {
        this.hydro = hydro;
    }

    public void Cooled(float energyExpelled)
    {
        hydro.Temperature -= energyExpelled / (hydro.mass * HydroConstants.SpecificHeatofIce);
    }

    public void Heated(float energyReceived)
    {
        if (hydro.Temperature == HydroConstants.FreezingTemperature)
            liquify(energyReceived);

        float sensibleHeat = -hydro.Temperature * hydro.mass * HydroConstants.SpecificHeatofIce;
        float remainingEnergy = energyReceived - sensibleHeat;

        if (remainingEnergy > 0)
        {
            hydro.Temperature = 0f;
            liquify(remainingEnergy);
        }
        else
            hydro.Temperature += energyReceived / (hydro.mass * HydroConstants.SpecificHeatofIce);
    }

    private void liquify(float energyRecieved)
    {
        float energyRemaining = energyRecieved - hydro.mass * HydroConstants.LatentHeatofFusion;
        if(energyRemaining > 0)
        {
            hydro.State = hydro.Water;
            hydro.State.Heated(energyRemaining);
        }
    }
}
