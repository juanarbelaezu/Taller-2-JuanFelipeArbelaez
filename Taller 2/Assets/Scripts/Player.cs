using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{

    [SerializeField] string name;
    public GameObject[] critters;
    public List<GameObject> listacritterspl;
    GameObject critteractual;

    // Start is called before the first frame update
    void Start()
    {
        critteractual = critters[0];
        listacritterspl = critters.ToList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
