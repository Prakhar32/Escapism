using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SteamTests
{
    [Test]
    public void HeatedRemainsSteam()
    {
        float mass = 50f;
        Matter matter = new Hydro(101f, mass);
        matter.Heated(100);
        Assert.IsTrue(matter.GetState().GetType().IsAssignableFrom(typeof(Steam)));
    }

    [Test]
    public void CooledIntoWater()
    {
        float mass = 50f;
        Matter matter = new Hydro(101f, mass);
        matter.Cooled(mass * Constants.kiloJouleMultiplier * 2.3f);
        Assert.IsTrue(matter.GetState().GetType().IsAssignableFrom(typeof(Water)));
    }

    [Test]
    public void CooledTwiceIntoIce()
    {
        float mass = 50f;
        Matter matter = new Hydro(101f, mass);
        matter.Cooled(mass * Constants.kiloJouleMultiplier * 2.3f);
        matter.Cooled(mass * Constants.kiloJouleMultiplier);
        Assert.IsTrue(matter.GetState().GetType().IsAssignableFrom(typeof(Ice)));
    }

    [Test]
    public void CoolingInsufficient()
    {
        float mass = 50f;
        Matter matter = new Hydro(101f, mass);
        matter.Cooled(mass * 10);
        Assert.IsTrue(matter.GetState().GetType().IsAssignableFrom(typeof(Steam)));
    }

    [Test]
    public void HeatedRequiresMoreCooling()
    {
        float mass = 50f;
        Matter matter = new Hydro(101f, mass);
        matter.Heated(mass * Constants.kiloJouleMultiplier * 2.3f);
        matter.Cooled(mass * Constants.kiloJouleMultiplier * 2.3f);
        Assert.IsFalse(matter.GetState().GetType().IsAssignableFrom(typeof(Water)));
    }
}
