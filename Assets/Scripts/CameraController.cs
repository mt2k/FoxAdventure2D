using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform farBackground;
    public Transform middleBackground;

    //private float lastXPosition;
    private Vector2 lastXPosition;

    public float minHeightCamera;
    public float maxHeightCamera;

    // Start is called before the first frame update
    void Start()
    {
        //lastXPosition = transform.position.x;
        lastXPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float clampedY = Mathf.Clamp(target.position.y, minHeightCamera, maxHeightCamera);
        transform.position = new Vector3(target.position.x, clampedY, transform.position.z);

        //float amountToMoveX = transform.position.x - lastXPosition;
        Vector2 amountToMoveX = new Vector2(transform.position.x - lastXPosition.x, transform.position.y - lastXPosition.y);

        farBackground.position = farBackground.position + new Vector3(amountToMoveX.x, 0, 0);
        middleBackground.position += new Vector3 (amountToMoveX.x * 0.5f, 0, 0);

        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        lastXPosition = transform.position;
    }
}
