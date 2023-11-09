using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePear : MonoBehaviour
{
    private GameManager dungeonMaster;
    public float bobbingSpeed = 2.0f;  // Speed of bobbing motion.
    public float bobbingAmount = 0.2f; // Amount of bobbing motion.
    public float rotationSpeed = 30.0f; // Speed of rotation.
    private Vector3 initialPosition;
    private float time = 0f;
    [SerializeField] GameObject glitch;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 newPosition = initialPosition;
        newPosition.y += Mathf.Sin(time * bobbingSpeed) * bobbingAmount;
        transform.position = newPosition;
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            gameObject.GetComponent<Collider>().enabled = false;
            dungeonMaster.IncreaseScore(7500);

            float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)) * 15;
            Instantiate(glitch, spawnPosition, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
