using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f); //In case laser goes through wall, this will kill it after 1/2 second to prevent lasers building up at infinity
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Enemy1"){
            other.gameObject.GetComponent<Enemy1>().Damage();
        }
        if (other.gameObject.tag == "Enemy2"){
            other.gameObject.GetComponent<Enemy2>().Damage();
        }
        /*if ((other.gameObject.tag != "Player") || (other.gameObject.tag != "UnitCenter")){
            Destroy(gameObject);
        }*/ //Taken care of with layers now
    }

}
