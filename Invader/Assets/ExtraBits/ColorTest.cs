using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.SetColor("_Color", new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
    }
}
