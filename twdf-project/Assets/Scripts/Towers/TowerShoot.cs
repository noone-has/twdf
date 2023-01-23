using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{

    [SerializeField] float Damage;
    [SerializeField] float Range;
    [SerializeField] float fireRate;
    GameObject[] enemies;
    float distance;
    float smallestDistance;
    GameObject enemyToShoot;

    void Start()
    {
        
    }

    void Update()
    {
        FindEnemy();
    }

    void FindEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        smallestDistance = Range;
        foreach(GameObject enemy in enemies)
        {
            distance = Vector2.Distance(enemy.transform.position, this.transform.position);
            if(distance < smallestDistance)
            {
                smallestDistance = distance;
                enemyToShoot = enemy;
            }
            if(smallestDistance == Range)
            {
                enemyToShoot = null;
            }
            
        }
        Debug.Log(smallestDistance);
        Debug.Log(enemyToShoot);
    }
}
