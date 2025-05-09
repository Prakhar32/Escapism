using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class IceTests
{
    [Test]
    public void HeatedToWater()
    {
        Matter ice = new Ice();
        Matter newState = ice.Heated();
        Assert.IsTrue(newState.GetType().IsAssignableFrom(typeof(Water)));
    }

    [Test]
    public void CoolingDoesNothing()
    {
        Matter ice = new Ice();
        Matter newState = ice.Cooled();
        Assert.IsTrue(newState.GetType().IsAssignableFrom(typeof(Ice)));
    }

    [Test]
    public void HeatingTwiceIntoSteam()
    {
        Matter matter = new Ice();
        matter = matter.Heated();
        matter = matter.Heated();
        Assert.IsTrue(matter.GetType().IsAssignableFrom(typeof(Steam)));
    }
}
