using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //IDK what this is but the internet says it works and i don't dare touch it

public class ProcGen : MonoBehaviour
{

    private Transform[] children;

    private float cooldownTime = 1f; // Cooldown time in seconds
    private bool isOnCooldown = false;

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
                Debug.Log("Child name: " + child.name);
            }

        }}

    }
    

    private IEnumerator ResetCooldown(){
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }

}
