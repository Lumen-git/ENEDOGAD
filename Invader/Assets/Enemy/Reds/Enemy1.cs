using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    private GameManager dungeonMaster;
    private int health;
    private int startingHealth;

    private Transform player;
    private Rigidbody enemyRB;
    [SerializeField] int MoveSpeed = 4;
    [SerializeField] GameObject deathParticles;
    [SerializeField] AudioClip audioClip;
    //[SerializeField] int MaxDist = 10;
    //[SerializeField] int MinDist = 5;

    [SerializeField] GameObject healPowerUp;
    [SerializeField] GameObject healthUpPowerUp;
    [SerializeField] GameObject damagePowerUp;

    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health = dungeonMaster.RequestHealth();
        startingHealth = health;
        UpdateColor();

        enemyRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Health Updates
        UpdateColor();
        if (health <= 0){
            dungeonMaster.IncreaseScore(10 * (startingHealth));
            tryDrop();
            GameObject tempPar = Instantiate(deathParticles, this.transform.position, Quaternion.identity);
            Destroy(tempPar, 1);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Destroy(gameObject);
        }

        //super simple movement
        transform.LookAt(player);
        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        enemyRB.velocity = this.transform.forward * MoveSpeed;

        bool proximity = Vector3.Distance(transform.position, player.position) > 40f;
        if (proximity) Destroy(gameObject);
    }

    public void Damage(){
        health = health - dungeonMaster.getDamage();
        UpdateColor();
    }

    private void UpdateColor(){
        Color myRed = new Color((float)health/10, 0f, 0f);
        GetComponent<Renderer>().material.SetColor("_Color", myRed);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", myRed);
    }

    private void tryDrop(){
        int randomNum = Random.Range(0,25);
        if (randomNum == 5){
            Instantiate(healPowerUp, this.transform.position, Quaternion.identity);
        }
        randomNum = Random.Range(0, 50);
        if (randomNum == 5 && dungeonMaster.getMaxHealth() < 6){
        Instantiate(healthUpPowerUp, this.transform.position, Quaternion.identity);
        }
        randomNum = Random.Range(0, 50);
        if (randomNum == 5 && dungeonMaster.getDamage() < 3){
        Instantiate(damagePowerUp, this.transform.position, Quaternion.identity);
        }
    }

}
