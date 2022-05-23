using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;

    public Transform playerBody;
    public float mouseSensitivity = 100f;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        // playerBody = GameObject.FindGameObjectWithTag("Character Body").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player Head").transform.position;
        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // playerBody.Rotate(Vector3.up * mouseX);
    }
}
