using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //IDK what this is but the internet says it works and i don't dare touch it

public class ProcGen : MonoBehaviour
{

    private Transform[] children;

    private float cooldownTime = 1f; // Cooldown time in seconds
    private bool isOnCooldown = false;
    private Transform player;
    private bool proximity = false;

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
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.position) < 25f){  //15 activates the spawner halfway into the next room, 22.5 is anywhere in next room
            proximity = true;
        } else {
            proximity = false;
        }

        if (!proximity){
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (!isOnCooldown){ //The player has 2 hit boxes that handles different things. This makes sure one one triggers this method
            isOnCooldown = true;
            StartCoroutine(ResetCooldown());

        
        if (other.gameObject.tag == "Player"){
            children = GetComponentsInChildren<Transform>();

            if (transform != null && children.Length > 0){  //exclude parent itself
                children = children.Where(child => child != transform).ToArray();
            }

            foreach (Transform child in children){  //For each child, which are the spawn nodes
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

    private List<float> validRotations = new List<float>();
    private string exits;

    private void spawnNorth(Transform node){

        List<string> roomName = active[Random.Range(0, active.Count)]; //Pick a random room from the active set
        GameObject toLoad = Resources.Load<GameObject>(roomName[0]);    //Load that model

        //If room is spawning north, it needs a southern exit
        exits = ""; //Set exits to an empty string
        validRotations = new List<float>(); //set validRotations to an empty list
        exits = roomName[1];    //set exits to the set of strings that represent valid exits 

        if (exits[0] == '1') {validRotations.Add(180f);}    //Assign proper valid rotations to validRotations
        if (exits[1] == '1') {validRotations.Add(90f);}
        if (exits[2] == '1') {validRotations.Add(0f);}
        if (exits[3] == '1') {validRotations.Add(-90f);}

        //Debug.Log(validRotations.Count);

        float chosenRotation = validRotations[Random.Range(0, validRotations.Count)];

        Instantiate(toLoad, node.position, Quaternion.Euler(0f, chosenRotation, 0f));
    }

    private void spawnEast(Transform node){
        List<string> roomName = active[Random.Range(0, active.Count)];
        GameObject toLoad = Resources.Load<GameObject>(roomName[0]);

        //If room is spawning east, it needs a western exit
        exits = "";
        validRotations = new List<float>();
        exits = roomName[1];

        if (exits[0] == '1') {validRotations.Add(-90f);}
        if (exits[1] == '1') {validRotations.Add(180f);}
        if (exits[2] == '1') {validRotations.Add(90f);}
        if (exits[3] == '1') {validRotations.Add(0f);}

        float chosenRotation = validRotations[Random.Range(0, validRotations.Count)];

        Instantiate(toLoad, node.position, Quaternion.Euler(0f, chosenRotation, 0f));
    }

    private void spawnSouth(Transform node){
        List<string> roomName = active[Random.Range(0, active.Count)];
        GameObject toLoad = Resources.Load<GameObject>(roomName[0]);

        //If room is spawning south, it needs a northern exit
        exits = "";
        validRotations = new List<float>();
        exits = roomName[1];

        if (exits[0] == '1') {validRotations.Add(180f);}
        if (exits[1] == '1') {validRotations.Add(90f);}
        if (exits[2] == '1') {validRotations.Add(0f);}
        if (exits[3] == '1') {validRotations.Add(-90f);}

        float chosenRotation = validRotations[Random.Range(0, validRotations.Count)];

        Instantiate(toLoad, node.position, Quaternion.Euler(0f, chosenRotation, 0f));
    }

    private void spawnWest(Transform node){
        List<string> roomName = active[Random.Range(0, active.Count)];
        GameObject toLoad = Resources.Load<GameObject>(roomName[0]);

        //if room is spawning west, it needs an eastern exit
        exits = "";
        validRotations = new List<float>();
        exits = roomName[1];

        if (exits[0] == '1') {validRotations.Add(-90f);}
        if (exits[1] == '1') {validRotations.Add(180f);}
        if (exits[2] == '1') {validRotations.Add(90f);}
        if (exits[3] == '1') {validRotations.Add(0f);}

        float chosenRotation = validRotations[Random.Range(0, validRotations.Count)];

        Instantiate(toLoad, node.position, Quaternion.Euler(0f, chosenRotation, 0f));
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
