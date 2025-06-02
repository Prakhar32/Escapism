using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HydroDisplayTests
{
    [UnityTest]
    public IEnumerator HydroNeedsToBeAssigned()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        HydroDisplay hydroDisplay = g.AddComponent<HydroDisplay>();
        yield return null;
        
        Assert.IsTrue( hydroDisplay == null );
    }

    [UnityTest]
    public IEnumerator Dependancyinitialised()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        HydroDisplay hydroDisplay = g.AddComponent<HydroDisplay>();
        hydroDisplay.SetHydro(new Hydro(-1, 50));
        yield return null;
        Assert.IsTrue(hydroDisplay != null );
    }

    [UnityTest]
    public IEnumerator SizeProportionalToMass()
    {
        GameObject g1 = new GameObject();
        HydroDisplay hydroDisplay1 = g1.AddComponent<HydroDisplay>();
        GameObject g2 = new GameObject();
        HydroDisplay hydroDisplay2 = g2.AddComponent<HydroDisplay>();
        float mass1 = 50f;
        float mass2 = 100f;
        
        hydroDisplay1.SetHydro(new Hydro(5, mass1));
        hydroDisplay2.SetHydro(new Hydro(5, mass2));

        yield return null;
        Assert.IsTrue (hydroDisplay1.GetVolume() < hydroDisplay2.GetVolume());
    }

    [UnityTest]
    public IEnumerator IceMoreVoluminousThanWater()
    {
        GameObject g1 = new GameObject();
        HydroDisplay waterDisplay = g1.AddComponent<HydroDisplay>();
        GameObject g2 = new GameObject();
        HydroDisplay iceDisplay = g2.AddComponent<HydroDisplay>();
        waterDisplay.SetHydro(new Hydro(5, 50));
        iceDisplay.SetHydro(new Hydro(-5, 50));
        yield return null;

        Assert.IsTrue(waterDisplay.GetVolume() < iceDisplay.GetVolume());
    }

    [UnityTest]
    public IEnumerator SteamMoreVoluminousThanIce()
    {
        GameObject g1 = new GameObject();
        HydroDisplay iceDisplay = g1.AddComponent<HydroDisplay>();
        GameObject g2 = new GameObject();
        HydroDisplay steamDisplay = g2.AddComponent<HydroDisplay>();
        iceDisplay.SetHydro(new Hydro(-5, 50));
        steamDisplay.SetHydro(new Hydro(105, 50));
        yield return null;

        Assert.IsTrue(iceDisplay.GetVolume() < steamDisplay.GetVolume());
    }

    [UnityTest]
    public IEnumerator StateChangeAffectVolume()
    {
        //Given
        GameObject g = new GameObject();
        HydroDisplay hydroDisplay = g.AddComponent<HydroDisplay>();
        float mass = 50f;
        Hydro hydro = new Hydro(-5, mass);
        hydroDisplay.SetHydro(hydro);
        yield return null;
        
        //When
        float initialVolume = hydroDisplay.GetVolume();
        hydro.Heated(5 * mass * Constants.kiloJouleMultiplier);
        float newVolume = hydroDisplay.GetVolume();

        //Then
        Assert.AreNotEqual(initialVolume, newVolume);
    }
}
