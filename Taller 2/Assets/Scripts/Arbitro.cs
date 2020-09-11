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
        if(fase == fase.Playerturn)
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

    void PlayerAttack()
    {

    }

    void PlayerAction()
    {

    }

    void EnemyTurn()
    {

    }
}
