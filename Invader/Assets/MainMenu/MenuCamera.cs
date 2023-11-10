using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{

    [SerializeField] float movementSpeed = .05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (transform.position.z >= 155.5f){
            transform.position = new Vector3(0,2.5f,-8.75f);
        }
    }
}
