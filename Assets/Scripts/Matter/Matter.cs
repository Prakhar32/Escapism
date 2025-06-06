using UnityEngine;

public interface Matter
{
    void Heated(float energyReceived);
    void Cooled(float energyExpelled);
    StateOfMatter GetState();
}
