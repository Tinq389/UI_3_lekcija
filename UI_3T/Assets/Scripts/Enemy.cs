using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    [SerializeField] private Image enemyImage;
	[SerializeField] protected int aggression = 5;

    public Image EnemyImage
    {
        get { return enemyImage; }
    }

}