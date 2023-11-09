using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InboundTeleporterPac : MonoBehaviour
{

    private bool warped = false;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (warped){
        timer += Time.deltaTime;

            if (timer >= 1){
                timer = 0f;
                warped = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.tag == "Player" && warped == false){
            warped = true;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z - 103.74f);
        }
    }

    }

