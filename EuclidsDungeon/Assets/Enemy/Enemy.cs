using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameManager dungeonMaster;
    [SerializeField] float health = 0;


    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        health = dungeonMaster.requestHealth();
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColor();
    }

    public void Damage(){
        health--;
        UpdateColor();

        if (health == 0){
            dungeonMaster.increaseScore();
            Destroy(gameObject);
        }
    }

    private void UpdateColor(){
        Color32 myRed = new Color32((byte)Mathf.Floor(health * 15), (byte)0, (byte)0, (byte)255);
        GetComponent<Renderer>().material.SetColor("_Color", myRed);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", myRed);
    }

}
