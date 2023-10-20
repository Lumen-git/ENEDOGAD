using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    private GameManager dungeonMaster;
    private int health = 5;
    private int MoveSpeed;

    private Transform player;
    private Rigidbody enemyRB;


    [SerializeField] GameObject healPowerUp;
    [SerializeField] GameObject healthUpPowerUp;
    [SerializeField] GameObject deathParticles;
    [SerializeField] AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        UpdateColor();
        MoveSpeed = Random.Range(2,7);
        enemyRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Health Updates
        UpdateColor();
        if (health <= 0){
            dungeonMaster.IncreaseScore(25);
            tryDrop();
            GameObject tempPar = Instantiate(deathParticles, this.transform.position, Quaternion.identity);
            Destroy(tempPar, 1);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Destroy(gameObject);
        }

        //super simple movement
        transform.LookAt(player);
        enemyRB.velocity = this.transform.forward * MoveSpeed;

        bool proximity = Vector3.Distance(transform.position, player.position) > 40f;
        if (proximity) Destroy(gameObject);
    }

    public void Damage(){
        health--;
        UpdateColor();
    }

    private void UpdateColor(){
        Color myGreen = new Color(0f, (MoveSpeed-2)/5f, 0f);
        GetComponent<Renderer>().material.SetColor("_Color", myGreen);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", myGreen);
    }

    private void tryDrop(){
        int randomNum = Random.Range(0,20);
        if (randomNum == 5){
            Instantiate(healPowerUp, this.transform.position, Quaternion.identity);
        }
        randomNum = Random.Range(0,30);
        if (randomNum == 5 && dungeonMaster.getMaxHealth() < 6){
            Instantiate(healthUpPowerUp, this.transform.position, Quaternion.identity);
        }
    }

}
