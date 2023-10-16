using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;
    private int score;
    private int maxEnemyHealth = 1;
    private int minEnemyHealth = 1;
    private float timer;

    private int maxHealth = 3;
    private int activeHealth = 3;
    private List<Image> healthBar;
    private GameObject player;
    private bool playerDead = false;

    void Start(){
        healthBar = new List<Image> {heart1, heart2, heart3};
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update(){
        //Increase score 1 per second
        timer += Time.deltaTime;

        if (timer >= 1 && !playerDead){
            timer = 0f;
            score++;
        }

        scoreText.text = "Score: " + score;
    }

    public int RequestHealth(){
        maxEnemyHealth = (int)(score/500 + 1);
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

    public void damagePlayer(){
        healthBar[activeHealth-1].enabled = false;
        activeHealth--;
        if (activeHealth == 0){
            Destroy(player);
            playerDead = true;
        }
    }

    public void healPlayer(){
        if (activeHealth < maxHealth){
            activeHealth++;
            healthBar[activeHealth-1].enabled = true;
        }
    }

    public int getScore(){
        return score;
    }

}
