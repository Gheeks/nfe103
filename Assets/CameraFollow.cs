using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Summoner;
    private Vector3 cameraOffset;

    [Range(0.01f, 2.0f)]
    public float smoothness = 2f;
    void Start()
    {
        cameraOffset = transform.position - Summoner.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Summoner.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
    }
}
