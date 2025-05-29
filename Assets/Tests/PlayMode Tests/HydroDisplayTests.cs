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
        Assert.IsTrue(hydroDisplay1.gameObject.transform.localScale.x < hydroDisplay2.gameObject.transform.localScale.x);
        Assert.IsTrue(hydroDisplay1.gameObject.transform.localScale.y < hydroDisplay2.gameObject.transform.localScale.y);
        Assert.IsTrue(hydroDisplay1.gameObject.transform.localScale.z < hydroDisplay2.gameObject.transform.localScale.z);
    }
}
