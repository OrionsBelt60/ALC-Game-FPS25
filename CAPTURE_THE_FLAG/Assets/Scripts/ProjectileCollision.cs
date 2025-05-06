using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public int damage = 5;
    void OnColliderEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();//Get the enemy script component
        if(other.gameObject.CompareTag("Enemy"))// check to see if hitting enemy
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

    }
    void Awake()
    {

        Destroy(gameObject,5);
}
}
