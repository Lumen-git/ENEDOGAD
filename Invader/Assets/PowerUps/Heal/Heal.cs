using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    //TEMPALTE VARS
    public float bobbingSpeed = 2.0f;  // Speed of bobbing motion.
    public float bobbingAmount = 0.2f; // Amount of bobbing motion.
    public float rotationSpeed = 30.0f; // Speed of rotation.
    private Vector3 initialPosition;
    [SerializeField] AudioClip audioClip;
    private float time = 0f;
    //TEMPLATE VARS

    private GameManager dungeonMaster;

    void Start()
    {
        //TEMPLATE START
        initialPosition = transform.position;
        //TEMPLATE START

        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
        dungeonMaster.healPlayer();
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        Destroy(gameObject);
    }

}
