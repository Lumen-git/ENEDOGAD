using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutboundTeleporter : MonoBehaviour
{

    private bool warped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.tag == "Player" && warped == false){
            warped = true;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x + 91.5f, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
        }

    }
}
