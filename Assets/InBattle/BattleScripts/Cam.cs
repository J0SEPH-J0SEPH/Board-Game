using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform CameraPos;
    public Transform Target;
    public float SmoothMovement = 0.1f;
    public Vector3 moveDirection;
    public float Speed = 10; 

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, SmoothMovement * Time.deltaTime);
        }

        moveDirection = transform.forward*Input.GetAxis("Vertical") + transform.right* Input.GetAxis("Horizontal");

        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            Target = null;
        }
        transform.position += Vector3.Normalize(moveDirection)*Time.deltaTime*Speed;
    }
}
