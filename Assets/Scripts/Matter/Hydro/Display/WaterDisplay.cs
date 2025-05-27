using UnityEngine;

public class WaterDisplay : MonoBehaviour
{
    private Hydro _hydro;
    public void SetHydro(Hydro hydro)
    {
        _hydro = hydro;
        setSize();
    }

    private void setSize()
    {
        float scale = _hydro.mass / HydroConstants.referenceMass;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void Start()
    {
        if(_hydro == null)
        {
            Destroy(this);
            throw new MissingReferenceException();
        }
    }
}
