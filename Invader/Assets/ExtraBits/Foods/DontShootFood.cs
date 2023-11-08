using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontShootFood : MonoBehaviour
{

    [SerializeField] AudioClip clip;
    private AudioSource audioSource;

    public float bobbingSpeed = 2.0f;  // Speed of bobbing motion.
    public float bobbingAmount = 0.2f; // Amount of bobbing motion.
    public float rotationSpeed = 30.0f; // Speed of rotation.
    private Vector3 initialPosition;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        audioSource = this.GetComponent<AudioSource>();
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
        if (other.gameObject.tag == "Laser"){
            AudioSource.PlayClipAtPoint(clip, GameObject.FindGameObjectsWithTag("MainCamera")[0].transform.position);
            Destroy(gameObject);
        }
    }

}
