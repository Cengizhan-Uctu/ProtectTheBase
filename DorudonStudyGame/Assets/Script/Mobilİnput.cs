using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobilİnput : MonoBehaviour
{
    private Touch isTouch;
    float countSpawn;
    [SerializeField] PlayerShoting shotingAndLookAt;
    [SerializeField] PlayerAnimation playerAnimation;

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            isTouch = Input.GetTouch(0);
            if (isTouch.phase == TouchPhase.Began)
            {
                playerAnimation.RunAnimationTure();
                playerAnimation.idleAnimationFalse();
                playerAnimation.FiringAnimationFalse();
                PlayerShoting.isFire = false;
            }
            if (isTouch.phase == TouchPhase.Moved)
            {
                playerAnimation.RunAnimationTure();
                playerAnimation.idleAnimationFalse();
                playerAnimation.FiringAnimationFalse();
                PlayerShoting.isFire = false;
            }
            if (isTouch.phase == TouchPhase.Ended)
            {
                playerAnimation.idleAnimationTrue();
                playerAnimation.RunAnimationFalse();
                PlayerShoting.isFire = true;
            }


        }
    }

}
