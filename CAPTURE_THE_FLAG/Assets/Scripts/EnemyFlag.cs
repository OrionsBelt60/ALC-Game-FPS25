
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlag : MonoBehaviour
{
    private GameManager gm;
    private Renderer flagRend;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();//has the flag bool that checks for win condition
        flagRend = GetComponent<Renderer>();//the renderer is on the object, that the script is on
        flagRend.enabled = true;
        
    }
    void OnTriggerEnter(Collider other)
    {
        gm.hasFlag = true;
        flagRend.enabled = false;
    }

}
