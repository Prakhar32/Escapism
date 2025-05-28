using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WaterDisplayTests
{
    [UnityTest]
    public IEnumerator HydroNeedsToBeAssigned()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        HydroDisplay waterDisplay = g.AddComponent<HydroDisplay>();
        yield return null;

        Assert.IsTrue(waterDisplay == null);
    }

    [UnityTest]
    public IEnumerator Dependancyinitialised()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        HydroDisplay waterDisplay = g.AddComponent<HydroDisplay>();
        waterDisplay.SetHydro(new Hydro(-1, 50));
        yield return null;
        Assert.IsTrue(waterDisplay != null);
    }

    [UnityTest]
    public IEnumerator SizeProportionalToMass()
    {
        GameObject g1 = new GameObject();
        HydroDisplay waterDisplay1 = g1.AddComponent<HydroDisplay>();
        GameObject g2 = new GameObject();
        HydroDisplay waterDisplay2 = g2.AddComponent<HydroDisplay>();
        float mass1 = 50f;
        float mass2 = 100f;

        waterDisplay1.SetHydro(new Hydro(-1, mass1));
        waterDisplay2.SetHydro(new Hydro(-1, mass2));

        yield return null;
        Assert.IsTrue(waterDisplay1.gameObject.transform.localScale.x < waterDisplay2.gameObject.transform.localScale.x);
        Assert.IsTrue(waterDisplay1.gameObject.transform.localScale.y < waterDisplay2.gameObject.transform.localScale.y);
        Assert.IsTrue(waterDisplay1.gameObject.transform.localScale.z < waterDisplay2.gameObject.transform.localScale.z);
    }
}
