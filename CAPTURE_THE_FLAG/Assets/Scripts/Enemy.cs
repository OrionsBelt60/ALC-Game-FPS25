using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

   
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{damage} damage points taken!");
        Debug.Log($"now at {Health} health");
        //take damage
    }
}
