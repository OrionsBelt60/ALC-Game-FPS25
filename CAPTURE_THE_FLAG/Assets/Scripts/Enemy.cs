using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;
    public int maxHp;
    public int scoreToGive;
    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;
    [Header("Path INfo")]
    public float yPathOffset;
    private List<Vector3> path;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHp;
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f,0.5f);
    }
    void UpdatePath()
    {
        //creates a navigation mesh
        // then calculates the most efficient path and stores the points that you must move to in a list.
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);
        path = navMeshPath.corners.ToList();
    }
    void ChaseTarget()
    {
        if(path.Count == 0)
        {
            return;
        }
        //move towards closest path

        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);
        if (transform.position == path[0] + new Vector3(0, yPathOffset, 0))
        {
            path.RemoveAt(0);
        }
    }
   
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        // CanInclude 
        //particles
        //animations
    }
    void Update()
    {
        //Look at target
        transform.LookAt(target.transform);
        //Vector3 dir (target.transform.position - tranasform.position).normalized;
        //float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        //transform.eulerAngles = Vector3.up * angle;

        //distance from enemy to player/target
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist <= attackRange)
        {
            
        }
    }
}
