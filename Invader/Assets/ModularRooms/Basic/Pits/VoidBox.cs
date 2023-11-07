using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidBox : MonoBehaviour
{

    private GameManager dungeonMaster;
    Rigidbody otherBody;
    [SerializeField] private Transform safePoint;

    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.tag == "Player"){
            otherBody = other.gameObject.GetComponent<Rigidbody>();
            //otherBody.constraints = RigidbodyConstraints.FreezePositionY;
            other.gameObject.transform.position = safePoint.position + new Vector3(0, .7f, 0);
            dungeonMaster.damagePlayer();
        } else if (other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2"){
            Destroy(other.gameObject);
        }

    }
}
