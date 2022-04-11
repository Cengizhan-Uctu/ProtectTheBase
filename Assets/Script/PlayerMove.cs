using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] FixedJoystick JoyStick;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float speed;
  

    private void Update()
    {
        rigidBody.velocity = new Vector3( JoyStick.Horizontal * speed, 0, JoyStick.Vertical*speed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f,2f), transform.position.y, Mathf.Clamp(transform.position.z, -3f, 3f));

        if (JoyStick.Horizontal!=0||JoyStick.Vertical!=0)
        {
            transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
        }
    }
    
}
