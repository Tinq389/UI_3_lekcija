using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    [SerializeField] private Weapon weapon;
    private Shield shield;

    private void Start()
    {
        shield = GetComponent<Shield>();
    }
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
        if (shield != null && shield.IsActive)
        {
            int blockedAmount = shield.BlockDamage(damage);
            Debug.Log($"Shield is ON! Blocked {damage - blockedAmount} damage.");
            damage = blockedAmount;
        }
        else
        {
            Debug.Log("Shield is OFF! Taking full damage.");
        }

        health -= damage;
        health = Mathf.Max(health, 0); // prevent negative health
        Debug.Log($"{name} took {damage} damage! Current Health: {health}");

        if (health == 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Debug.Log(name + " has been defeated.");
        gameObject.SetActive(false);
    }
}