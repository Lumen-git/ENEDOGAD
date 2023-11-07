using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPointsZone : MonoBehaviour
{

    private GameManager dungeonMaster;
    private float timer;
    [SerializeField] int bonusPoints;

    // Start is called before the first frame update
    void Start()
    {
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "Player"){
            timer += Time.deltaTime;

            if (timer >= 1){
                timer = 0f;
                dungeonMaster.IncreaseScore(bonusPoints);
            }
        }
    }

}
