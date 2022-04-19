using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : SingeltonGeneric<PlayerMove>
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, Mathf.Clamp(transform.position.z, -1f, 4f));
        rigidBody.velocity = new Vector3(JoyStick.Horizontal * speed, 0, JoyStick.Vertical * speed);
       
        if (JoyStick.Horizontal != 0 || JoyStick.Vertical != 0)
        {
            PlayerAnimation.Instance.RunAnimationTure();
            PlayerShoting.isFire = false;
            transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
        }
        else
        {
            PlayerAnimation.Instance.idleAnimationTrue();
            PlayerShoting.isFire = true;
            
        }
    }
}
