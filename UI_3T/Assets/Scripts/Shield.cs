using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private int shieldStrength = 10;  // The shield's total damage absorption (adjustable in the Inspector)
    private bool isBroken = false;

    public bool IsBroken { get { return isBroken; } }
    public int ShieldStrength { get { return shieldStrength; } }

    // Method to absorb damage
    public int AbsorbDamage(int damage)
    {
        if (shieldStrength > 0)
        {
            // If the shield still has strength left, it absorbs some or all of the damage
            int absorbed = Mathf.Min(damage, shieldStrength);
            shieldStrength -= absorbed;  // Reduce shield strength by the amount absorbed

            // If the shield strength reaches zero, mark it as broken
            if (shieldStrength <= 0)
            {
                isBroken = true;
            }

            return absorbed;  // Return the amount absorbed
        }
        else
        {
            // If the shield is broken, it doesn't absorb any more damage
            return 0;
        }
    }
}


