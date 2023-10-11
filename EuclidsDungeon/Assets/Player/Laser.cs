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
        if (other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().Damage();
        }
        if (other.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
    }

}
