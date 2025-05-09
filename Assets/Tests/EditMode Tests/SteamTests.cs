using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SteamTests
{
    [Test]
    public void HeatedRemainsSteam()
    {
        Matter steam = new Steam();
        Matter newState = steam.Heated(); 
        Assert.IsTrue(newState.GetType().IsAssignableFrom(typeof(Steam)));
    }

    [Test]
    public void CooledIntoWater()
    {
        Matter steam = new Steam();
        Matter newState = steam.Cooled();
        Assert.IsTrue(newState.GetType().IsAssignableFrom(typeof(Water)));
    }

    [Test]
    public void CooledTwiceIntoIce()
    {
        Matter matter = new Steam();
        matter = matter.Cooled();
        matter = matter.Cooled();
        Assert.IsTrue(matter.GetType().IsAssignableFrom(typeof(Ice)));
    }
}
