using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] GameObject banner;
    private Material bannerRend;
    private float offset;

    void Start()
    {
        bannerRend = banner.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "Player"){
            if (Input.GetKey(KeyCode.D)){
                if (Input.GetKey(KeyCode.LeftShift)){
                    offset += runSpeed * Time.deltaTime;
                    bannerRend.SetTextureOffset("_MainTex", new Vector2(offset, 0));
                } else {
                    offset += walkSpeed * Time.deltaTime;;
                    bannerRend.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }

        }

    }
}
}
