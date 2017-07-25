using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class otherMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public float ToMove;
    public Transform target1;
    public Transform target2;
    private float direction = 1.0f;
    private float currentPosition = 0f;

    void Update()
    {
        // use movetowards
        currentPosition = speed * Time.deltaTime;
        if(currentPosition == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, currentPosition);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.position, currentPosition);
        }
        //transform.position = Vector3.Lerp(target1.position, target2.position, Mathf.PingPong(currentPosition, 5f));
    }
} 