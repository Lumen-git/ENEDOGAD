using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacPellet : MonoBehaviour
{

    private GameManager dungeonMaster;

    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.tag == "Player"){
            gameObject.GetComponent<Collider>().enabled = false;
            dungeonMaster.doPellet();
            Destroy(gameObject);
        }
    }
}
