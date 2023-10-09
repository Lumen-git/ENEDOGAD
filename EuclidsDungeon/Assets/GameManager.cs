using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private int score;
    private int maxEnemyHealth = 1;
    private float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Increase score 1 per second
        timer += Time.deltaTime;

        if (timer >= 1){
            timer = 0f;
            score++;
        }
    }

    public int requestHealth(){
        maxEnemyHealth = (score/100)^2 + 1;
        if (maxEnemyHealth > 17) maxEnemyHealth = 17;
        int minEnemyHealth = maxEnemyHealth - 6;
        if (minEnemyHealth <= 0) minEnemyHealth = 1;
        return (int)Mathf.Round(Random.Range(minEnemyHealth, maxEnemyHealth));
    }

    public void increaseScore(){
        score += 10;
    }
}
