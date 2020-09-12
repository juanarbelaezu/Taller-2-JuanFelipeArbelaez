using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum fase
{
    Start,
    Playerturn,
    EnemyTurn,
    Win,
    Lost
}

public class Arbitro : MonoBehaviour
{
    GameObject plcritter;
    GameObject iacritter;
    Critter statspl;
    Critter statsop;
    public static Arbitro instance = null;

    Oponent opt;
    Player pl;

    public Transform plspawn;
    public Transform enemyspwan;

    private float timer = 0;

    public fase fase;

    //Ui

    public GameObject attack;
    public GameObject suporttab;

    private int crittercount = 0;
    private int crittercounterop = 0;

    // Commandos

    private IaAttack iattack;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<Player>().GetComponent<Player>();
        opt = FindObjectOfType<Oponent>().GetComponent<Oponent>();
        fase = fase.Start;
        StartBattle();
    }

    // Update is called once per frame
    void Update()
    {
        if (plcritter == null && crittercount < pl.critters.Length)
        {
            crittercount += 1;
            plcritter = Instantiate(pl.critters[crittercount], plspawn);
            statspl = plcritter.GetComponent<Critter>();
            fase = fase.Playerturn;
        }
        else if (iacritter == null && crittercounterop < opt.crittersop.Length)
        {
            crittercounterop += 1;
            iacritter = Instantiate(pl.critters[crittercounterop], enemyspwan);
            statsop = plcritter.GetComponent<Critter>();
            fase = fase.EnemyTurn;
        }


        if (fase == fase.Playerturn)
        {
            Playerturn();
        }
        if(timer <= 0 && fase != fase.Start)
        {
            ChangeTurn();
        }
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }

    void StartBattle()
    {
        plcritter = Instantiate(pl.critters[0], plspawn);
        statspl = plcritter.GetComponent<Critter>();
        iacritter = Instantiate(opt.crittersop[0], enemyspwan);
        statsop = iacritter.GetComponent<Critter>();
        iattack = new IaAttack(iacritter, plcritter, statspl, statsop);

        if(statspl.Speed > statsop.Speed)
        {
            fase = fase.Playerturn;
        }

        if(statsop.Speed > statspl.Speed)
        {
            fase = fase.EnemyTurn;
        }
    }

    void ChangeTurn()
    {
        if(fase == fase.Playerturn)
        {
            fase = fase.EnemyTurn;
        }
        else if (fase == fase.EnemyTurn)
        {
            fase = fase.Playerturn;
        }
    }

    void Playerturn()
    {
        if(statspl.Support == false)
        {
            timer = 60;
            attack.SetActive(true);
        }
        else
        {
            timer = 60;
            attack.SetActive(true);
            suporttab.SetActive(true);
        }
    }

    public void PlayerAttack()
    {
        if (statspl.afinidad == statsop.afinidad || statspl.afinidad == afinidad.Wind && statsop.afinidad == afinidad.Dark || statspl.afinidad == afinidad.Water && statsop.afinidad == afinidad.Fire)
        {
            float damageVal = (statspl.Atk + statspl.Power) * 0.5f;
            statsop.Hp -= damageVal;
            Debug.Log("Daño realizado al oponente" + damageVal);
            fase = fase.EnemyTurn;
            EnemyTurn();
        }
        else if (statspl.afinidad == afinidad.Dark && statsop.afinidad == afinidad.Light || statspl.afinidad == afinidad.Light && statsop.afinidad == afinidad.Dark || statspl.afinidad == afinidad.Fire && statsop.afinidad == afinidad.Water || statspl.afinidad == afinidad.Water && statsop.afinidad == afinidad.Wind || statspl.afinidad == afinidad.Earth && statsop.afinidad == afinidad.Wind)
        {
            float damageVal = (statspl.Atk + statspl.Power) * 2f;
            statsop.Hp -= damageVal;
            Debug.Log("Daño realizado al oponente" + damageVal);
            fase = fase.EnemyTurn;
            EnemyTurn();
        }
        else if (statspl.afinidad == afinidad.Fire && statsop.afinidad == afinidad.Earth)
        {
            float damageVal = (statspl.Atk + statspl.Power) * 0f;
            statsop.Hp -= damageVal;
            Debug.Log("Daño realizado al oponente" + damageVal);
            fase = fase.EnemyTurn;
            EnemyTurn();
        }
        else
        {
            float damageVal = (statspl.Atk + statspl.Power) * 1f;
            statsop.Hp -= damageVal;
            Debug.Log("Daño realizado al oponente" + damageVal);
            fase = fase.EnemyTurn;
            EnemyTurn();
        }
    }

    public void PlayerAtckSup()
    {
        statspl.Atk += 0.2f;
        suporttab.SetActive(false);
    }

    public void PlayerDefSup()
    {
        statspl.Def += 0.2f;
        suporttab.SetActive(false);
    }

    public void PlayerSpeedSup()
    {
        statspl.Speed += 0.2f;
        suporttab.SetActive(false);
    }

    public void Result()
    {
        if(plcritter == null)
        {
            crittercount += 1;
            plcritter = Instantiate(pl.critters[crittercount], plspawn);
            statspl = plcritter.GetComponent<Critter>();
        }
        else if (iacritter == null)
        {
            crittercounterop += 1;
            iacritter = Instantiate(pl.critters[crittercounterop], enemyspwan);
            statsop = plcritter.GetComponent<Critter>();
        }
    }

    void EnemyTurn()
    {
        timer = 60;
        attack.SetActive(false);
        suporttab.SetActive(false);

        if(statsop.Support == false)
        {
            iattack.Execute();
            fase = fase.Playerturn;
        }
        else if(statsop.Support == true)
        {
            int rnd = Random.Range(0, 3);
        }
    }
}
