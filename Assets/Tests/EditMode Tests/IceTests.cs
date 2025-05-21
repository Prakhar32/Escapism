using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class IceTests
{
    [Test]
    public void HeatedToWater()
    {
        float mass = 50f;
        Matter matter = new Hydro(-1f, mass);
        matter.Heated(mass * 400);
        Assert.IsTrue(matter.GetState().GetType().IsAssignableFrom(typeof(Water)));
    }

    [Test]
    public void CoolingDoesNotChangeState()
    {
        float mass = 50f;
        Matter matter = new Hydro(-1f, mass);
        matter.Cooled(mass * 10);
        Assert.IsTrue(matter.GetState().GetType().IsAssignableFrom(typeof(Ice)));
    }

    [Test]
    public void HeatingTwiceIntoSteam()
    {
        float mass = 50f;
        Matter matter = new Hydro(-1f, mass);
        matter.Heated(mass * 1000);
        matter.Heated(mass * 5 * Constants.MegaJouleMultiplier);
        Assert.IsTrue(matter.GetState().GetType().IsAssignableFrom(typeof(Steam)));
    }

    [Test]
    public void InsufficientHeating()
    {
        float mass = 50f;
        Matter matter = new Hydro(-1f, mass);
        matter.Heated(mass * 5);
        Assert.IsFalse(matter.GetState().GetType().IsAssignableFrom(typeof(Water)));
    }


    [Test]
    public void CoolingMoreRequiredMoreHeating()
    {
        //Given
        float mass = 50f;
        Matter matter = new Hydro(-1f, mass);
        
        //When
        matter.Cooled(mass * 400);
        matter.Heated(mass * 400);

        //Then
        Assert.IsFalse(matter.GetState().GetType().IsAssignableFrom(typeof(Water)));
    }
}
