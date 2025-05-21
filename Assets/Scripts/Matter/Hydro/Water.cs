using UnityEngine;

public class Water : StateOfMatter
{
    private Hydro hydro;
    internal Water(Hydro hydro)
    {
        this.hydro = hydro;
    }

    public void Heated(float energyReceived)
    {
        if (hydro.Temperature == HydroConstants.VaporizationTemperature)
            vaporize(energyReceived);


        float sensibleHeat = (HydroConstants.VaporizationTemperature - hydro.Temperature) * HydroConstants.SpecificHeatofWater * hydro.mass;
        float remainingHeat = energyReceived - sensibleHeat;

        if(remainingHeat > 0)
        {
            hydro.Temperature = HydroConstants.VaporizationTemperature;
            vaporize(remainingHeat);
        }
        else
            hydro.Temperature += energyReceived / (hydro.mass * HydroConstants.SpecificHeatofWater);
    }

    private void vaporize(float energy)
    {
        energy -= HydroConstants.LatentHeatofVaporization * hydro.mass;

        if (energy > 0)
        {
            hydro.State = hydro.Steam;
            hydro.State.Heated(energy);
        }
    }

    public void Cooled(float energyExpelled)
    {
        if (hydro.Temperature == 0)
            convertintoIce(energyExpelled);

        float sensibleHeat = hydro.Temperature * hydro.mass * HydroConstants.SpecificHeatofWater;
         float remainingEnergy = energyExpelled - sensibleHeat;

        if (energyExpelled > 0)
        {
            hydro.Temperature = 0;
            convertintoIce(remainingEnergy);
        }
        else
        {
            hydro.Temperature -= energyExpelled / (hydro.mass * HydroConstants.SpecificHeatofWater);
        }
    }

    private void convertintoIce(float energy)
    {
        energy -= HydroConstants.LatentHeatofFusion * hydro.mass;
        if(energy >= 0)
        {
            hydro.State = hydro.Ice;
            hydro.State.Cooled(energy);
        }
    }
}
