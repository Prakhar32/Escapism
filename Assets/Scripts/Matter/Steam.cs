using UnityEngine;

public class Steam : Matter
{
    public Matter Cooled()
    {
        return new Water();
    }

    public Matter Heated()
    {
        return this;
    }
}
