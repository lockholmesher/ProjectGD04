using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private float smoothSpeed = 8f;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desirePos = player.transform.position +offset;
        Vector3 smoothPos = Vector3.Lerp(this.transform.position,desirePos,smoothSpeed*Time.deltaTime);
        this.transform.position = smoothPos;
    }
}
