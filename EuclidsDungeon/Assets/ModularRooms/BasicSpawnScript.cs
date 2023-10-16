using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class BasicSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    private Transform player;
    private bool proximity = false;
    private GameManager dungeonMaster;
    private float timer = 1.9f; //Start the timer close to spawn to get enemies going faster

    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        proximity = ((Vector3.Distance(this.transform.position, player.position) < 22.5f) && (Vector3.Distance(this.transform.position, player.position) > 7.5f)) ? true : false;  //15 activates the spawner halfway into the next room, 22.5 is anywhere in next room
    
        if (proximity){
            this.timer += Time.deltaTime;

            if (this.timer >= 2.5){
                spawn();
            }
        }

    }

    private void spawn(){
        this.timer = 0f + Random.Range(-.5f,.5f);   //Add a little variation to spawn
        int randomSpawn = Random.Range(0,10);
        if (dungeonMaster.getScore() > 10 && randomSpawn > 6){
            Instantiate(enemy2, new Vector3(this.transform.position.x, .75f, this.transform.position.z), Quaternion.identity);
        } else {
            Instantiate(enemy1, new Vector3(this.transform.position.x, .75f, this.transform.position.z), Quaternion.identity);
        }
    }

}
