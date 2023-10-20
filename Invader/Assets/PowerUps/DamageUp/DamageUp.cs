using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{
    //TEMPALTE VARS
    public float bobbingSpeed = 2.0f;  // Speed of bobbing motion.
    public float bobbingAmount = 0.2f; // Amount of bobbing motion.
    public float rotationSpeed = 30.0f; // Speed of rotation.
    private Vector3 initialPosition;
    private float time = 0f;
    //TEMPLATE VARS

    void Start()
    {
        //TEMPLATE START
        initialPosition = transform.position;
        //TEMPLATE START
    }


    void Update()
    {
        //TEMPLATE UPDATE
        time += Time.deltaTime;
        Vector3 newPosition = initialPosition;
        newPosition.y += Mathf.Sin(time * bobbingSpeed) * bobbingAmount;
        transform.position = newPosition;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        //TEMPLATE UPDATE
    }

    public void powerUpDo(){
        Destroy(gameObject);
    }

}
