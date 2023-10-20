using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{

    private GameManager dungeonMaster;

    private int MoveSpeed = 7;

    private Transform player;
    private Rigidbody enemyRB;



    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyRB = this.GetComponent<Rigidbody>();
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
