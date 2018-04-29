using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    [SerializeField]private float health = 100f;
    public Text gameOvers;

    public int scoreValue = 15;
    public void applyDamage(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            
            Destroy(gameObject);
            ScoreManager.score += scoreValue;
            gameOvers.text = "Game Over";

        }
    }
}
