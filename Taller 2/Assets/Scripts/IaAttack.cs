using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaAttack : ICommand
{

    protected GameObject ene;
    protected GameObject pl;
    protected Critter plc;
    protected Critter plo;

    public IaAttack(GameObject ene, GameObject pl, Critter plc, Critter plo)
    {
        this.ene = ene;
        this.pl = pl;
        this.plc = plc;
        this.plo = plo;
    }

    public void Execute()
    {
        if (plo.afinidad == plc.afinidad || plo.afinidad == afinidad.Wind && plo.afinidad == afinidad.Dark || plc.afinidad == afinidad.Water && plo.afinidad == afinidad.Fire)
        {
            float damageVal = (plo.Atk + plo.Power) * 0.5f;
            plc.Hp -= damageVal;
            Debug.Log("Daño realizado al jugador" + damageVal);
        }
        else if (plo.afinidad == afinidad.Dark && plc.afinidad == afinidad.Light || plo.afinidad == afinidad.Light && plc.afinidad == afinidad.Dark || plo.afinidad == afinidad.Fire && plc.afinidad == afinidad.Water || plo.afinidad == afinidad.Water && plc.afinidad == afinidad.Wind || plo.afinidad == afinidad.Earth && plc.afinidad == afinidad.Wind)
        {
            float damageVal = (plo.Atk + plo.Power) * 2f;
            plc.Hp -= damageVal;
            Debug.Log("Daño realizado al jugador" + damageVal);
        }
        else if (plo.afinidad == afinidad.Fire && plc.afinidad == afinidad.Earth)
        {
            float damageVal = (plo.Atk + plo.Power) * 0f;
            plc.Hp -= damageVal;
            Debug.Log("Daño realizado al jugador" + damageVal);           
        }
        else
        {
            float damageVal = (plo.Atk + plo.Power) * 1f;
            plc.Hp -= damageVal;
            Debug.Log("Daño realizado al jugador" + damageVal);
        }
    }
}
