using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class BasicSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject glitch;
    private Transform player;
    private GameManager dungeonMaster;
    private float timer = 1.9f; //Start the timer close to spawn to get enemies going faster
    private float glitchTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //15 activates the spawner halfway into the next room, 22.5 is anywhere in next room, 7.5 is same room

        //Basic enemies
        if ((Vector3.Distance(this.transform.position, player.position) < 22.5f) && (Vector3.Distance(this.transform.position, player.position) > 7.5f)){
            //Basic Spawning 
            timer += Time.deltaTime;
            if (this.timer >= 2.5){
                spawn();
            }
        }


        //Glitch
        if (Vector3.Distance(this.transform.position, player.position) < 7.5f){
            glitchTimer += Time.deltaTime;
            if (glitchTimer >= 15f){
                float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
                Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)) * 15;
                Instantiate(glitch, spawnPosition, Quaternion.identity);
                glitchTimer = -1000f;
            }
        }

    }

    private void spawn(){
        this.timer = 0f + Random.Range(-.5f,.5f);   //Add a little variation to spawn
        int randomSpawn = Random.Range(0,10);
        if (dungeonMaster.getScore() > 1000 && randomSpawn > 6){
            Instantiate(enemy2, new Vector3(this.transform.position.x, .75f, this.transform.position.z), Quaternion.identity);
        } else {
            Instantiate(enemy1, new Vector3(this.transform.position.x, .75f, this.transform.position.z), Quaternion.identity);
        }
    }

}
