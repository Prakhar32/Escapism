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
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void Start()
    {
        if (_hydro == null)
        {
            Destroy(this);
            throw new MissingReferenceException();
        }
    }
}
