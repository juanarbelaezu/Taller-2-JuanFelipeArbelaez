using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour
{

    [SerializeField] string nameop;
    public GameObject[] crittersop;
    GameObject critteractualop;

    // Start is called before the first frame update
    void Start()
    {
        critteractualop = crittersop[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
