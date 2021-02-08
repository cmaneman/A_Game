using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatfromScript : MonoBehaviour
{
    public GameObject MovingPlatform1;
    public Transform OriginPoint; //Start
    public Transform EndPoint; //Target
    public float speed = 1.0f;
    public float journeyLength = 4.0f;
    private float startTime = 1;
    public float coverDistance;

    public bool loopRepeat = false;
    //public float move;

    /*void Start()
    {
         //-16.24, 1.39, 19.6
    }*/

    void FixedUpdate()
    {
        if (!loopRepeat)
        {
            coverDistance = (Time.time - startTime) * speed;
            transform.position = Vector3.Lerp(OriginPoint.position, EndPoint.position, coverDistance / journeyLength);
        }

        if (loopRepeat)
        {
            StartCoroutine(PlatformDelay());//Does nothing noticeable
            coverDistance = Mathf.PingPong(Time.time - startTime, journeyLength / speed);
            transform.position = Vector3.Lerp(OriginPoint.position, EndPoint.position, coverDistance / journeyLength);
            StartCoroutine(PlatformDelay());//Does nothing noticeable
        }
    }
    IEnumerator PlatformDelay()//Does nothing noticeable
    {
        yield return new WaitForSeconds(3);
    }
}
