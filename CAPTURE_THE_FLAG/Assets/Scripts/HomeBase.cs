using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    private GameManager gm;
    private Renderer flagRend;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        flagRend = GameObject.Find("FlagHome").GetComponent<Renderer>();
        flagRend.enabled = false; // hide flag.
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gm.hasFlag)
        {
            Debug.Log("Player has reached homebase and has placed the flag");
            flagRend.enabled = true;
        }
    }
}
