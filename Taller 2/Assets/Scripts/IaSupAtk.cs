using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaSupAtk : ICommand
{
    protected GameObject character;
    protected Critter critter;

    public IaSupAtk(GameObject character, Critter critter)
    {
        this.character = character;
        this.critter = critter;
    }

    public void Execute()
    {
        critter.Atk += 0.2f;
    }
}
