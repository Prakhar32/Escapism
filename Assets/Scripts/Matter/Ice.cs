using UnityEngine;

public class Ice : Matter
{
    public Matter Cooled()
    {
        return this;
    }

    public Matter Heated()
    {
        return new Water();
    }
}
