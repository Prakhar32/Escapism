using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WaterTests
{
    [Test]
    public void MassCanOnlyBePositive()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Hydro(0, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Hydro(0, -0));
    }

    [Test]
    public void HeatedIntoSteam()
    {
        Matter matter = new Hydro(10f, 50f);
        matter.Heated(1000 * Constants.kiloJouleMultiplier);
        Assert.IsTrue(matter.GetState().GetType().IsAssignableFrom(typeof(Steam)));
    }

    [Test]
    public void CooledIntoIce()
    {
        Matter matter = new Hydro(10f, 50f);
        matter.Cooled(400 * Constants.kiloJouleMultiplier);
        Assert.IsTrue(matter.GetState().GetType().IsAssignableFrom(typeof(Ice)));
    }

    [Test]
    public void CoolingNotSufficientForStateChange()
    {
        float mass = 50f;
        Matter matter = new Hydro(10f, mass);
        matter.Cooled(mass * 40);
        Assert.IsFalse(matter.GetState().GetType().IsAssignableFrom(typeof(Ice)));
    }

    [Test]
    public void InsufficientHeatSupplied()
    {
        float mass = 50f;
        Matter matter = new Hydro(10f, mass);
        matter.Heated(mass * 40);
        Assert.IsFalse(matter.GetState().GetType().IsAssignableFrom(typeof(Steam)));
    }
}
