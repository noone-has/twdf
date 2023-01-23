using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] float Armor;

    public float getHealth()
    {
        return Health;
    }
    public float getArmor()
    {
        return Armor;
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage / Armor;
        if(Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
