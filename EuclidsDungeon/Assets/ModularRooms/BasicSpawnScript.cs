using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private Transform player;
    private bool proximity = false;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        proximity = (Vector3.Distance(this.transform.position, player.position) < 22.5f) ? true : false;  //15 activates the spawner halfway into the next room, 22.5 is anywhere in next room
    
        if (proximity){
            timer += Time.deltaTime;

            if (timer >= 4){
                timer = 0f;
                Vector3 offset = new Vector3(Random.Range(-.7f, .7f), 0f, Random.Range(-.7f, .7f));
                Instantiate(enemy, (this.transform.position + offset), Quaternion.identity);
            }
        }

    }

}
