using UnityEngine;

public class HydroDisplay : MonoBehaviour
{
    protected Hydro _hydro;

    public void SetHydro(Hydro hydro)
    {
        _hydro = hydro;
        SetSize();
    }

    private void SetSize()
    {
        float scale = _hydro.mass / HydroConstants.referenceMass;
        float modifiedScale = scale * GetVolume();
        transform.localScale = new Vector3(modifiedScale, modifiedScale, modifiedScale);
    }

    void Start()
    {
        if (_hydro == null)
        {
            Destroy(this);
            throw new MissingReferenceException();
        }
    }

    public float GetVolume()
    {
        float volume = 0;
        float density = getDensity();

        volume = _hydro.mass / density;
        return volume;
    }

    private float getDensity()
    {
        float density = 0f;
        if (_hydro.GetState().GetType().IsAssignableFrom(typeof(Ice)))
            density = HydroConstants.DensityofIce;
        else if (_hydro.GetState().GetType().IsAssignableFrom(typeof(Water)))
            density = HydroConstants.DensityofWater;
        else
            density = HydroConstants.DensityofSteam;

        return density;
    }
}
