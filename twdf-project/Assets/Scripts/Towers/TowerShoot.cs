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
    float health;
    float lowestHealth;
    float highestHealth;
    float biggestDistance;
    GameObject enemy = null;

    void Start()
    {
        StartCoroutine("Shoot");
    }

    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        GameObject enemy = findHighestHPEnemy(0); //temporary, need to make something that picks the function according to the mode the tower is on
        Debug.Log(enemy);
        enemy.GetComponent<Damageable>().TakeDamage(Damage);
        yield return new WaitForSeconds(fireRate);
        StartCoroutine("Shoot");
    }

    GameObject findClosestEnemy(float smallestDistance)
    {
        enemyToShoot = null;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            distance = Vector2.Distance(enemy.transform.position, this.transform.position);
            if(distance < smallestDistance && distance <= Range)
            {
                smallestDistance = distance;
                enemyToShoot = enemy;
            }
        }
        return enemyToShoot;
    }
    GameObject findFurthestEnemy(float biggestDistance)
    {
        enemyToShoot = null;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            distance = Vector2.Distance(enemy.transform.position, this.transform.position);
            if(distance > biggestDistance && distance <= Range)
            {
                biggestDistance = distance;
                enemyToShoot = enemy;
            }
        }
        return enemyToShoot;
    }
    GameObject findLowestHPEnemy(float lowestHealth)
    {
        enemyToShoot = null;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            distance = Vector2.Distance(enemy.transform.position, this.transform.position);
            health = enemy.GetComponent<Damageable>().getHealth();
            if(distance <= Range && health < lowestHealth)
            {
                lowestHealth = health;
                enemyToShoot = enemy;
            }
        }
        return enemyToShoot;
    }
    GameObject findHighestHPEnemy(float highestHealth)
    {
        enemyToShoot = null;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            distance = Vector2.Distance(enemy.transform.position, this.transform.position);
            health = enemy.GetComponent<Damageable>().getHealth();
            if(distance <= Range && health > highestHealth)
            {
                highestHealth = health;
                enemyToShoot = enemy;
            }
        }
        return enemyToShoot;
    }
    GameObject findLowestArmorEnemy(float lowestArmor)
    {
        enemyToShoot = null;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            distance = Vector2.Distance(enemy.transform.position, this.transform.position);
            armor = enemy.GetComponent<Damageable>().getArmor();
            if(distance <= Range && armor < lowestArmor)
            {
                lowestArmor = armor;
                enemyToShoot = enemy;
            }
        }
        return enemyToShoot;
    }
        GameObject findHighestArmorEnemy(float highestArmor)
    {
        enemyToShoot = null;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            distance = Vector2.Distance(enemy.transform.position, this.transform.position);
            armor = enemy.GetComponent<Damageable>().getArmor();
            if(distance <= Range && armor > highestArmor)
            {
                highestArmor = armor;
                enemyToShoot = enemy;
            }
        }
        return enemyToShoot;
    }
}
