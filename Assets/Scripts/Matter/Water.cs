using UnityEngine;

public class Water : Matter
{
    public Matter Heated()
    {
        return new Steam();
    }

    public Matter Cooled()
    {
        return new Ice();
    }
}
