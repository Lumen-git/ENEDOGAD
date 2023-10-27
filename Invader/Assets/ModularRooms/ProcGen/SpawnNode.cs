using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour
{

    private bool canSpawn = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(){
        canSpawn = false;
    }

    void OnTriggerExit(){
        canSpawn = true;
    }

    public bool CanSpawn(){
        return canSpawn;
    }

}
