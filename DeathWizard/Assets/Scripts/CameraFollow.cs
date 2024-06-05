using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // private Vector3 offset = new Vector3(0f, 1f, -10f);
    // private float smoothTime = 0f;
    // private Vector3 velocity = Vector3.zero;

    // [SerializeField] public Transform target;



    public Transform player;
    private float cameraZ;

    // Start is called before the first frame update
    void Start()
    {
        cameraZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + 0.5f, player.position.y + 1f, cameraZ);



    }

    // void FixedUpdate()
    // {
    //     Vector3 targetPosition = target.position + offset;
    //     transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    // }
}
