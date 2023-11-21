using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogoLaser : MonoBehaviour
{

    private int MoveSpeed = 25;
    // Start is called before the first frame update
    void Start()
    {
        //In case laser goes through wall, this will kill it after 1/2 second to prevent lasers building up at infinity
    }

    // Update is called once per frame
    void Update()
    {
        float moveDelta = MoveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveDelta, 0, 0));
    }

    

}
