using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum afinidad
{
    Fire, //0
    Wind, //2
    Water, //3
    Earth, //4
    Dark, //5
    Light //6
}

public class Critter : MonoBehaviour
{ 
    [SerializeField] string nombrec;
    [SerializeField] float atk;
    [SerializeField] float def;
    [SerializeField] float speed;
    [SerializeField] bool support;
    [SerializeField] float power;
    [SerializeField] float hp;
    public afinidad afinidad;

    Arbitro arbitro;

    public float Speed { get => speed; set => speed = value; }
    public float Def { get => def; set => def = value; }
    public float Atk { get => atk; set => atk = value; }
    public bool Support { get => support; set => support = value; }
    public float Power { get => power; set => power = value; }
    public float Hp { get => hp; set => hp = value; }

    // Start is called before the first frame update
    void Start()
    {
        arbitro = FindObjectOfType<Arbitro>().GetComponent<Arbitro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
            arbitro.Result();
        }
    }
}
