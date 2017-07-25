using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this will be a simple Roomba bot AI steering script to practice raycasting
public class Raycast2 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //1. raycast in front of us...

        //1a. consturct the ray
        Ray ray = new Ray(transform.position, transform.forward);

        //2. if the raycast was TRUE, then randomly turn left or right
        if (Physics.Raycast(ray, 2f))
        {
            float randomNumber = Random.Range(0f, 100f);
            if (randomNumber < 50f)
            {
                transform.Rotate(0f, -180f, 0f);
            }
            else
            {
                transform.Rotate(0f, 180f, 0f);
            }
        }
        else
        {// 3. else, if the raycast was FALSE, there is nothing in front of usm so move forward
            transform.Translate(0f, 0f, 60f * Time.deltaTime); //Time.deltTa
        }


    }
}
