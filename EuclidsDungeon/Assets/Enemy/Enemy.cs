using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameManager dungeonMaster;
    private int health;
    private int startingHealth;


    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        health = dungeonMaster.RequestHealth();
        startingHealth = health;
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColor();
        if (health <= 0){
            dungeonMaster.IncreaseScore(10);
            Destroy(gameObject);
        }
    }

    public void Damage(){
        health--;
        UpdateColor();
    }

    private void UpdateColor(){
        Color myRed = new Color((float)health/10, 0f, 0f);
        GetComponent<Renderer>().material.SetColor("_Color", myRed);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", myRed);
    }

}
