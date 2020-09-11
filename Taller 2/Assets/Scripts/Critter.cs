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
    [SerializeField] int atk;
    [SerializeField] int def;
    [SerializeField] int speed;
    [SerializeField] bool support;
    public afinidad afinidad;

    public int Speed { get => speed; set => speed = value; }
    public int Def { get => def; set => def = value; }
    public int Atk { get => atk; set => atk = value; }
    public bool Support { get => support; set => support = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
