using System;
using UnityEngine;

public class Hydro : Matter
{
    internal StateOfMatter State;
    internal float Temperature;
    internal float mass;
    internal StateOfMatter Ice{ get;private set; }
    internal StateOfMatter Water {  get; private set; }
    internal StateOfMatter Steam {  get; private set; }

    public Hydro(float initialTemperature, float mass)
    {
        if (mass <= 0)
            throw new ArgumentOutOfRangeException("Mass can only be positive");

        this.mass = mass;
        Temperature = initialTemperature;

        initialiseStates();

        if (Temperature < 0)
            State = Ice;
        else if (Temperature < 100)
            State = Water;
        else
            State = Steam;

    }

    private void initialiseStates()
    {
        Ice = new Ice(this);
        Water = new Water(this);
        Steam = new Steam(this);
    }

    public void Cooled(float energyExpelled)
    {
        State.Cooled(energyExpelled);
    }

    public StateOfMatter GetState()
    {
        return State;
    }

    public void Heated(float energyReceived)
    {
        State.Heated(energyReceived);
    }
}
