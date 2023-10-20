using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{

    private GameManager dungeonMaster;

    private int MoveSpeed = 7;

    private Transform player;
    private Rigidbody enemyRB;

    private AudioSource audioSource;

    void Awake(){
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyRB = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.time = Random.Range(0f, audioSource.clip.length);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {   
        //super simple movement
        transform.LookAt(player);
        enemyRB.velocity = this.transform.forward * MoveSpeed;
        bool proximity = Vector3.Distance(transform.position, player.position) > 30f;
        if (proximity) Destroy(gameObject);

        GetComponent<Renderer>().material.SetColor("_Color", new Color(((transform.position.x*75)%100)/100f, ((transform.position.z*75)%100)/100f, 0f));
    }

}
