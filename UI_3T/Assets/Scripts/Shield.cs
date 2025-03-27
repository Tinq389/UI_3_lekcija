using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shield : MonoBehaviour
{
    [SerializeField] private int maxBlockValue = 10;
    [SerializeField] private int maxUses = 5;
    [SerializeField] private Button shieldButton;
    [SerializeField] private TMP_Text shieldStatusText;

    private int remainingUses;
    public bool IsActive { get; private set; } = false;
    private void Start()
    {
        remainingUses = maxUses;
        UpdateShieldStatus();
    }
    public void ToggleShield()
    {
        if (remainingUses <= 0)
        {
            Debug.Log("Shield is broken! Can't activate anymore.");
            return;
        }

        IsActive = !IsActive;
        Debug.Log(IsActive ? "Shield Activated!" : "Shield Deactivated!");
    
        if (IsActive)
            AudioManager.instance.PlayShieldActivateSound();
        else
            AudioManager.instance.PlayShieldDeactivateSound();
        
        UpdateShieldStatus(); 
    }

    public int BlockDamage(int incomingDamage)
    {
        if (!IsActive) return incomingDamage;

        int damageBlocked = Random.Range(2, Mathf.Min(incomingDamage, maxBlockValue));
        remainingUses--;

        Debug.Log($"Shield blocked {damageBlocked} damage! Remaining uses: {remainingUses}");
        UpdateShieldStatus();

        if (remainingUses <= 0)
        {
            BreakShield();
        }

        return Mathf.Max(0, incomingDamage - damageBlocked);
    }

    private void BreakShield()
    {
        IsActive = false;
        Debug.Log("Shield is broken! It can't be used anymore.");
    
        if (shieldButton != null)
            shieldButton.interactable = false;

        AudioManager.instance.PlayShieldBreakSound();
        UpdateShieldStatus();
    }

    private void UpdateShieldStatus()
    {
        if (shieldStatusText != null)
        {
            if (remainingUses <= 0)
            {
                shieldStatusText.text = "Shield Broken!";
            }
            else if (IsActive)
            {
                shieldStatusText.text = $"Shield Active! Uses Left: {remainingUses}";
            }
            else
            {
                shieldStatusText.text = "Shield Inactive";
            }
        }
    }
}
