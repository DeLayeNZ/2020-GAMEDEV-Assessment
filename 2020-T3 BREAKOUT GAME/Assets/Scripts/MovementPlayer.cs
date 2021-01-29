using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    readonly float EDGE = 6.5f;
    float speed = 6;


    void Update()
    {
        Vector3 pos = transform.position;
        float delta = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        pos.x += delta;

        if (pos.x < -EDGE)
        {
            pos.x = -EDGE;
        }
        else if (pos.x > EDGE)
        {
            pos.x = EDGE;
        }

        transform.position = pos;
    }
}
