using UnityEngine;

public class IceDisplay : MonoBehaviour
{
    private Hydro _hydro;

    public void setHydro(Hydro ice) 
    {
        _hydro = ice; 
        setSize();
    }

    private void setSize()
    {
        float scale = _hydro.mass / HydroConstants.referenceMass;
        transform.localScale = new Vector3 (scale, scale, scale);
    }

    void Start()
    {
        if( _hydro == null )
            Destroy(this);
    }
}
