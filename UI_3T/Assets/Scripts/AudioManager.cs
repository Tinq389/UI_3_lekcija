using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip shieldActivateSound;
    [SerializeField] private AudioClip shieldDeactivateSound;
    [SerializeField] private AudioClip shieldBreakSound;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayAttackSound()
    {
        PlaySFX(attackSound);
    }
    public void PlayShieldActivateSound()
    {
        PlaySFX(shieldActivateSound);
    }
    public void PlayShieldDeactivateSound()
    {
        PlaySFX(shieldDeactivateSound);
    }
    public void PlayShieldBreakSound()
    {
        PlaySFX(shieldBreakSound);
    }
}