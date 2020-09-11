using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] string name;
    public GameObject[] critters;
    GameObject critteractual;

    // Start is called before the first frame update
    void Start()
    {
        critteractual = critters[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
