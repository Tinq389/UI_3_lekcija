using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;

    [SerializeField] private Weapon weapon;

    public Weapon Weapon
    {
        get { return weapon; }
    }

    public virtual int Attack()
    {
        return weapon.GetDamage();
    }

    public void GetHit(int damage)
    {
        Debug.Log(name + " starting health: " + health);
        health -= damage;
        health = Mathf.Max(health, 0); // Ensure health doesn't go below 0
        Debug.Log(name + " health after hit: " + health);

        if (health == 0)
        {
            Die();
        }
    }

    public void GetHit(Weapon weapon)
    {
        Debug.Log(name + " starting health: " + health);
        health -= weapon.GetDamage();
        health = Mathf.Max(health, 0); // Ensure health doesn't go below 0
        Debug.Log(name + " health after hit by: " + weapon.name + " : " + health);

        if (health == 0)
        {
            Die();
        }
    }

    // Virtual method for character death (now can be overridden)
    protected virtual void Die()
    {
        Debug.Log(name + " has been defeated.");
        gameObject.SetActive(false); // Disable instead of destroying
    }
}