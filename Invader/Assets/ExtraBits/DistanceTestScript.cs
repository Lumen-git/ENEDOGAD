using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTestScript : MonoBehaviour
{

    private Transform player;
    private bool proximity = false;
    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.position) < 22.5f){  //15 activates the spawner halfway into the next room, 22.5 is anywhere in next room
            proximity = true;
        } else {
            proximity = false;
        }

        Color blockColor = (proximity) ? new Color(0f,1f,0f): new Color(1f, 0f, 0f);
        GetComponent<Renderer>().material.SetColor("_Color", blockColor);
    }
}
