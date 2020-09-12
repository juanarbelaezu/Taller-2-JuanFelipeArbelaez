using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaSupSpe : MonoBehaviour
{
    protected GameObject character;
    protected Critter critter;

    public IaSupSpe(GameObject character, Critter critter)
    {
        this.character = character;
        this.critter = critter;
    }

    public void Execute()
    {
        critter.Speed += 0.2f;
    }
}
