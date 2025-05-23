using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class IceDisplayTests
{
    [UnityTest]
    public IEnumerator HydroNeedsToBeAssigned()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        IceDisplay iceDisplay = g.AddComponent<IceDisplay>();
        yield return null;
        
        Assert.IsTrue( iceDisplay == null );
    }

    [UnityTest]
    public IEnumerator Dependancyinitialised()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        IceDisplay iceDisplay = g.AddComponent<IceDisplay>();
        iceDisplay.setHydro(new Hydro(-1, 50));
        yield return null;
        Assert.IsTrue( iceDisplay != null );
    }

    [UnityTest]
    public IEnumerator SizeProportionalToMass()
    {
        GameObject g1 = new GameObject();
        IceDisplay iceDisplay1 = g1.AddComponent<IceDisplay>();
        GameObject g2 = new GameObject();
        IceDisplay iceDisplay2 = g2.AddComponent<IceDisplay>();
        float mass1 = 50f;
        float mass2 = 100f;
        
        iceDisplay1.setHydro(new Hydro(-1, mass1));
        iceDisplay2.setHydro(new Hydro(-1, mass2));

        yield return null;
        Assert.IsTrue(iceDisplay1.gameObject.transform.localScale.x < iceDisplay2.gameObject.transform.localScale.x);
        Assert.IsTrue(iceDisplay1.gameObject.transform.localScale.y < iceDisplay2.gameObject.transform.localScale.y);
        Assert.IsTrue(iceDisplay1.gameObject.transform.localScale.z < iceDisplay2.gameObject.transform.localScale.z);
    }
}
