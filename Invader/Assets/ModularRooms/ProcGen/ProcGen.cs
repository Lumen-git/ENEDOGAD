using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //IDK what this is but the internet says it works and i don't dare touch it

public class ProcGen : MonoBehaviour
{

    private Transform[] children;

    private float cooldownTime = 1f; // Cooldown time in seconds
    private bool isOnCooldown = false;

    //ROOMS
    private static List<List<string>> grays = new List<List<string>>{
        new List<string> { "Grays/LinearHall", "1010"},
        new List<string> { "Grays/LinearRoom", "1010"},
        new List<string> { "Grays/QuadHall", "1111"},
        new List<string> { "Grays/QuadRoom", "1111"},
        new List<string> { "Grays/T-Hall", "1101"},
        new List<string> { "Grays/T-Room", "1101"},
        new List<string> { "Grays/TurnHall", "1100"},
        new List<string> { "Grays/TurnRoom", "1100"},
    };

    //Set default room type
    private List<List<string>> active = grays;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (!isOnCooldown){ //The player has 2 hitboxes that handles different things. This makes sure one one triggers this method
            isOnCooldown = true;
            StartCoroutine(ResetCooldown());

        
        if (other.gameObject.tag == "Player"){
            children = GetComponentsInChildren<Transform>();

            if (transform != null && children.Length > 0){  //exclude parent itself
                children = children.Where(child => child != transform).ToArray();
            }

            foreach (Transform child in children){  //For each child, which are the spawn nodes
                //TODO
                //If North -> Spawn North
                //If South -> Spawn South
                //If East -> Spawn East
                //If West -> Spawn West
                // 0 = N, 1 = E, 2 = S, 3 = W
                int direction = getDir(child);
                bool open = CanSpawn(child);
                
                if (direction == 0 && open){
                    spawnNorth(child);
                }
                else if (direction == 1 && open){
                    spawnEast(child);
                }
                else if (direction == 2 && open){
                    spawnSouth(child);
                }
                else if (direction == 3 && open){
                    spawnWest(child);
                }
            }

        }}

    }
    

    private IEnumerator ResetCooldown(){
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }

    private int getDir(Transform other){
        Vector3 direction = other.position - transform.position;

        if (direction.z > 0){return 0;}//North
        if (direction.x > 0){return 1;}//East
        if (direction.z < 0){return 2;}//South
        if (direction.x < 0){return 3;}//West
        return -1;
    }

    private void spawnNorth(Transform node){
        List<string> roomName = active[Random.Range(0, active.Count)];
        GameObject toLoad = Resources.Load<GameObject>(roomName[0]);
        Instantiate(toLoad, node.position, Quaternion.identity);
    }

    private void spawnEast(Transform node){
        List<string> roomName = active[Random.Range(0, active.Count)];
        GameObject toLoad = Resources.Load<GameObject>(roomName[0]);
        Instantiate(toLoad, node.position, Quaternion.identity);
    }

    private void spawnSouth(Transform node){
        List<string> roomName = active[Random.Range(0, active.Count)];
        GameObject toLoad = Resources.Load<GameObject>(roomName[0]);
        Instantiate(toLoad, node.position, Quaternion.identity);
    }

    private void spawnWest(Transform node){
        List<string> roomName = active[Random.Range(0, active.Count)];
        GameObject toLoad = Resources.Load<GameObject>(roomName[0]);
        Instantiate(toLoad, node.position, Quaternion.identity);
    }

    public bool CanSpawn(Transform node){
        Vector3 rayOrigin = node.position;
        Vector3 rayDirection = Vector3.up;
        if (Physics.Raycast(rayOrigin, rayDirection, 3f)){
            return false;
        }
        return true;
    }
    

}
