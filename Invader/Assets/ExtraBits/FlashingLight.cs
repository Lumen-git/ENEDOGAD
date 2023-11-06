using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{

    [SerializeField] float delay;
    [SerializeField] float minIntensity;
    [SerializeField] float maxIntensity;
    private Light flashingLight;
    private float timeElapsed;
    private string pattern = "mmamammmmammamamaaamammma";

    private void Awake()
    {
        
        flashingLight = GetComponent<Light>();
        flashingLight.intensity = maxIntensity;
 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 10 FLUORESCENT FLICKER
	    //LIGHT_STYLE(10, "mmamammmmammamamaaamammma");

         timeElapsed += Time.deltaTime;
 
        if(timeElapsed >= delay){
            timeElapsed = 0;
            if (pattern[0] == 'm'){
                flashingLight.intensity = maxIntensity;
            } else if (pattern[0] == 'a'){
                flashingLight.intensity = minIntensity;
            }
            pattern = pattern.Substring(1) + pattern[0];
        }
    
    }
}
