using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformFAN : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0f;

    private float startTime;
    private float journeyLength;
    private bool isMoving = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + endPosition;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            isMoving = !isMoving;
        }


        if (isMoving)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(fractionOfJourney, 1));
        }
    }
}
