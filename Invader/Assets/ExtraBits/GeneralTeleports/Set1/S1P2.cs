using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1P2 : MonoBehaviour
{

    private bool warped = false;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (warped){timer += Time.deltaTime;}
        if (timer >= .5f){
            timer = 0f;
            warped = false;
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            warped = true;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x - 135f, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 270f);
        }
    }

}
