using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WaterTests
{
    [Test]
    public void HeatedIntoSteam()
    {
        Matter water = new Water();
        Matter newState = water.Heated();
        Assert.IsTrue(newState.GetType().IsAssignableFrom(typeof(Steam)));
    }

    [Test]
    public void CooledIntoIce()
    {
        Matter water = new Water();
        Matter newState = water.Cooled(); 
        Assert.IsTrue(newState.GetType().IsAssignableFrom(typeof(Ice)));
    }
}
