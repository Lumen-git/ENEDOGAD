using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;
    private int maxEnemyHealth = 1;
    private int minEnemyHealth = 1;
    private float timer;

    void Start()
    {
        Debug.Log(gameObject.name);
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

        scoreText.text = "Score: " + score;
    }

    public int RequestHealth(){
        maxEnemyHealth = (int)(score/750 + 1);
        if (maxEnemyHealth > 10) maxEnemyHealth = 10;
        if (maxEnemyHealth >= 5){
            minEnemyHealth = maxEnemyHealth - 4;
        }

        //Debug.Log("Max Health: " + maxEnemyHealth);
        //Debug.Log("Min Health: " + minEnemyHealth);


        int assignedHealth = Random.Range(minEnemyHealth, maxEnemyHealth+1);
        //Debug.Log("Spawned Health: " + assignedHealth);
        return assignedHealth;
    }
    
    public void IncreaseScore(int amount){
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
