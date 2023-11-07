using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class GravityWell : MonoBehaviour
{

    Rigidbody otherBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            otherBody = other.gameObject.GetComponent<Rigidbody>();
            otherBody.constraints = RigidbodyConstraints.None;
            otherBody.constraints = RigidbodyConstraints.FreezeRotation;
        } else if (other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2"){
            Destroy(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "Player" && other.gameObject.transform.position.y > .7f){
            otherBody = other.gameObject.GetComponent<Rigidbody>();
            otherBody.transform.position = new Vector3(otherBody.transform.position.x, .8f, otherBody.transform.position.z);
            otherBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
    }
}
