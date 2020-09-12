using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Oponent : MonoBehaviour
{

    [SerializeField] string nameop;
    public GameObject[] crittersop;
    public List<GameObject> listacrittersop;
    GameObject critteractualop;

    // Start is called before the first frame update
    void Start()
    {
        critteractualop = crittersop[0];
        listacrittersop = crittersop.ToList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
