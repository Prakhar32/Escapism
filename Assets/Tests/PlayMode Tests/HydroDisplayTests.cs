using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HydroDisplayTests
{
    private HydroDisplay getNewDisplay(float inititalTemperature, float mass)
    {
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        HydroDisplay hydroDisplay = g.AddComponent<HydroDisplay>();
        Hydro hydro = new Hydro(inititalTemperature, mass);
        hydroDisplay.SetHydro(hydro);
        return hydroDisplay;
    }

    [UnityTest]
    public IEnumerator HydroNeedsToBeAssigned()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        HydroDisplay hydroDisplay = g.AddComponent<HydroDisplay>();
        yield return null;
        
        Assert.IsTrue( hydroDisplay == null );
    }

    [UnityTest]
    public IEnumerator Dependancyinitialised()
    {
        LogAssert.ignoreFailingMessages = true;
        HydroDisplay hydroDisplay = getNewDisplay(-5, 50);
        yield return null;
        Assert.IsTrue(hydroDisplay != null );
    }

    [UnityTest]
    public IEnumerator VolumeProportionalToMass()
    {
        HydroDisplay hydroDisplay1 = getNewDisplay(5, 50);
        HydroDisplay hydroDisplay2 = getNewDisplay(5, 100);

        yield return null;
        Assert.IsTrue (hydroDisplay1.GetVolume() < hydroDisplay2.GetVolume());
    }

    [UnityTest]
    public IEnumerator IceMoreVoluminousThanWater()
    {
        HydroDisplay waterDisplay = getNewDisplay(5, 50);
        HydroDisplay iceDisplay = getNewDisplay(-5, 50);
        yield return null;

        Assert.IsTrue(waterDisplay.GetVolume() < iceDisplay.GetVolume());
    }

    [UnityTest]
    public IEnumerator SteamMoreVoluminousThanIce()
    {
        HydroDisplay iceDisplay = getNewDisplay(-5, 50);
        HydroDisplay steamDisplay = getNewDisplay(105, 50);
        yield return null;

        Assert.IsTrue(iceDisplay.GetVolume() < steamDisplay.GetVolume());
    }

    [UnityTest]
    public IEnumerator StateChangeAffectVolume()
    {
        //Given
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
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

    [UnityTest]
    public IEnumerator SizeProportionalToVolume()
    {
        GameObject g1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        HydroDisplay iceDisplay = g1.AddComponent<HydroDisplay>();
        Hydro ice = new Hydro(-5, 50);
        iceDisplay.SetHydro(ice);

        GameObject g2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        HydroDisplay waterDisplay = g1.AddComponent<HydroDisplay>();
        Hydro water = new Hydro(5, 50);
        waterDisplay.SetHydro(water);

        yield return null;

        Vector3 bounds1 = g1.GetComponent<MeshRenderer>().bounds.size;
        Vector3 bounds2 = g2.GetComponent<MeshRenderer>().bounds.size;
        
        Assert.IsTrue(bounds1.magnitude > bounds2.magnitude);
    }
}
