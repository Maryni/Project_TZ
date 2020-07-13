using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    float dist = 5f;
    [SerializeField] Camera camera;
    private void FixedUpdate()
    {

        Move();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + camera.transform.forward * dist * Time.deltaTime;
        }
    }
}
