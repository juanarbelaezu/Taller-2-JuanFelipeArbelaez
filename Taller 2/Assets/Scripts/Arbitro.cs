using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] int crittercount = 0;
    [SerializeField] int crittercounterop = 0;

    public Text vidapl;
    public Text vidaop;

    // Commandos

    private IaAttack iattack;
    private IaSupAtk supatk;
    private IaSupDef supdef;
    private IaSupSpe supspe;

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
        if (plcritter == null)
        {
            crittercount += 1;
            plcritter = Instantiate(pl.critters[crittercount], plspawn);
            statspl = plcritter.GetComponent<Critter>();
            fase = fase.Playerturn;
        }
        else if (iacritter == null)
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

        vidapl.text = statspl.Hp.ToString();
        vidaop.text = statsop.Hp.ToString();

        if(crittercount > 3)
        {
            fase = fase.Lost;
            SceneManager.LoadScene("Lost");
        }

        if (crittercounterop > 3)
        {
            fase = fase.Win;
            SceneManager.LoadScene("Win");
        }
    }

    void StartBattle()
    {
        plcritter = Instantiate(pl.critters[0], plspawn);
        statspl = plcritter.GetComponent<Critter>();
        iacritter = Instantiate(opt.crittersop[0], enemyspwan);
        statsop = iacritter.GetComponent<Critter>();
        iattack = new IaAttack(iacritter, plcritter, statspl, statsop);
        supatk = new IaSupAtk(iacritter, statsop);
        supdef = new IaSupDef(iacritter, statsop);
        supspe = new IaSupSpe(iacritter, statsop);

        if (statspl.Speed > statsop.Speed)
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
            vidaop.text = statsop.Hp.ToString();
            EnemyTurn();
        }
        else if (statspl.afinidad == afinidad.Dark && statsop.afinidad == afinidad.Light || statspl.afinidad == afinidad.Light && statsop.afinidad == afinidad.Dark || statspl.afinidad == afinidad.Fire && statsop.afinidad == afinidad.Water || statspl.afinidad == afinidad.Water && statsop.afinidad == afinidad.Wind || statspl.afinidad == afinidad.Earth && statsop.afinidad == afinidad.Wind)
        {
            float damageVal = (statspl.Atk + statspl.Power) * 2f;
            statsop.Hp -= damageVal;
            Debug.Log("Daño realizado al oponente" + damageVal);
            fase = fase.EnemyTurn;
            vidaop.text = statsop.Hp.ToString();
            EnemyTurn();
        }
        else if (statspl.afinidad == afinidad.Fire && statsop.afinidad == afinidad.Earth)
        {
            float damageVal = (statspl.Atk + statspl.Power) * 0f;
            statsop.Hp -= damageVal;
            Debug.Log("Daño realizado al oponente" + damageVal);
            fase = fase.EnemyTurn;
            vidaop.text = statsop.Hp.ToString();
            EnemyTurn();
        }
        else
        {
            float damageVal = (statspl.Atk + statspl.Power) * 1f;
            statsop.Hp -= damageVal;
            Debug.Log("Daño realizado al oponente" + damageVal);
            fase = fase.EnemyTurn;
            vidaop.text = statsop.Hp.ToString();
            EnemyTurn();
        }
    }

    public void PlayerAtckSup()
    {
        statspl.Atk += 0.2f;
        suporttab.SetActive(false);
        fase = fase.EnemyTurn;
        EnemyTurn();
    }

    public void PlayerDefSup()
    {
        statspl.Def += 0.2f;
        suporttab.SetActive(false);
        fase = fase.EnemyTurn;
        EnemyTurn();

    }

    public void PlayerSpeedSup()
    {
        statspl.Speed += 0.2f;
        suporttab.SetActive(false);
        fase = fase.EnemyTurn;
        EnemyTurn();
    }

    public void Result()
    {
        if(plcritter == null)
        {
            crittercount += 1;
            plcritter = Instantiate(pl.critters[crittercount], plspawn);
            statspl = plcritter.GetComponent<Critter>();
            vidapl.text = statspl.Hp.ToString();
        }
        else if (iacritter == null)
        {
            crittercounterop += 1;
            iacritter = Instantiate(pl.critters[crittercounterop], enemyspwan);
            statsop = plcritter.GetComponent<Critter>();
            vidaop.text = statsop.Hp.ToString();
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
            vidapl.text = statspl.Hp.ToString();
            fase = fase.Playerturn;
        }
        else if(statsop.Support == true)
        {
            int rnd = Random.Range(0, 3);

            if(rnd == 0)
            {
                iattack.Execute();
                vidapl.text = statspl.Hp.ToString();
                fase = fase.Playerturn;
            }
            if(rnd == 1)
            {
                supatk.Execute();
                Debug.Log("Oponente Aumento ataque");
                fase = fase.Playerturn;
            }
            if (rnd == 2)
            {
                supdef.Execute();
                Debug.Log("Oponente Aumento defensa");
                fase = fase.Playerturn;
            }
            if (rnd == 3)
            {
                supspe.Execute();
                Debug.Log("Oponente Aumento velocidad");
                fase = fase.Playerturn;
            }
        }
    }
}
