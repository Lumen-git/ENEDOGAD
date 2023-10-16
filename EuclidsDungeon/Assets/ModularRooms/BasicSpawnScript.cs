using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private Transform player;
    private bool proximity = false;
    private float timer = 1.9f; //Start the timer close to spawn to get enemies going faster

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        proximity = ((Vector3.Distance(this.transform.position, player.position) < 22.5f) && (Vector3.Distance(this.transform.position, player.position) > 7.5f)) ? true : false;  //15 activates the spawner halfway into the next room, 22.5 is anywhere in next room
    
        if (proximity){
            this.timer += Time.deltaTime;

            if (this.timer >= 2.5){
                this.timer = 0f;
                //Vector3 offset = new Vector3(Random.Range(-.7f, .7f), this.transform.position.y , Random.Range(-.7f, .7f));
                Instantiate(enemy, new Vector3(this.transform.position.x, .75f, this.transform.position.z), Quaternion.identity);
            }
        }

    }

}
