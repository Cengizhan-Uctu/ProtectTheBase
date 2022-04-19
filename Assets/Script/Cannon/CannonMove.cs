using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMove : SingeltonGeneric<CannonMove>
{
    [SerializeField] FixedJoystick JoyStick;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float speed;
    #region singelton
    private void Awake()
    {
        MakeSingelton(this);
    }
    #endregion
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, transform.position.z);
        rigidBody.velocity = new Vector3(JoyStick.Horizontal * speed, 0, 0);
    }
}
