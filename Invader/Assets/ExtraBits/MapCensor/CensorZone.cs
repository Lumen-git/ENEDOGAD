using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CensorZone : MonoBehaviour
{

    [SerializeField] RenderTexture miniMapMain;
    [SerializeField] Texture2D miniMapError;
    [SerializeField] RawImage target;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "Player"){
            target.texture = miniMapError;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "Player"){
            target.texture = miniMapMain;
        }
    }
}
