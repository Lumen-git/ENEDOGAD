using UnityEngine;
using System.Collections;

public class RotatingExample1 : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;
    
    [SerializeField]
    private Vector3 targetOffset;

    private void LateUpdate()
    {
        transform.position = targetToFollow.position + targetOffset;
    }
}
