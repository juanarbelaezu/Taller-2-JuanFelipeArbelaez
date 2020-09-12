using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaSupDef : ICommand
{
    protected GameObject character;
    protected Critter critter;

    public IaSupDef(GameObject character, Critter critter)
    {
        this.character = character;
        this.critter = critter;
    }

    public void Execute()
    {
        critter.Def += 0.2f;
    }
}
