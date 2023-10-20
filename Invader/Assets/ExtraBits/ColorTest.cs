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
        GetComponent<Renderer>().material.SetColor("_Color", new Color(((transform.position.x*75)%100)/100f, ((transform.position.z*75)%100)/100f, 0f));
    }
}
