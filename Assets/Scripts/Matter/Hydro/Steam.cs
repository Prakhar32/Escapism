using UnityEngine;

public class Steam : StateOfMatter
{
    private Hydro hydro;

    internal Steam(Hydro hydro)
    {
        this.hydro = hydro;
    }

    public void Cooled(float energyExpelled)
    {
        if (hydro.Temperature == HydroConstants.FreezingTemperature)
            liquify(energyExpelled);

        float sensibleHeat = (hydro.Temperature - HydroConstants.VaporizationTemperature) * 
            hydro.mass * HydroConstants.SpecificHeatofSteam;
        float remaningEnergy = energyExpelled - sensibleHeat;

        if(remaningEnergy >= 0)
        {
            hydro.Temperature = HydroConstants.VaporizationTemperature;
            liquify(remaningEnergy);
        }
        else
            hydro.Temperature -= energyExpelled / (HydroConstants.SpecificHeatofSteam * hydro.mass);
    }

    private void liquify(float energyExpelled)
    {
        float energyRemaining = energyExpelled - hydro.mass * HydroConstants.LatentHeatofVaporization;
        if (energyRemaining > 0)
        {
            hydro.State = hydro.Water;
            hydro.State.Cooled(energyRemaining);
        }
    }

    public void Heated(float energyReceived)
    {
        hydro.Temperature += energyReceived / (HydroConstants.SpecificHeatofSteam * hydro.mass);
    }
}
