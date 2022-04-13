using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMove : MonoBehaviour
{
    private Touch isTouch;
    [SerializeField] float speed = 1;

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            isTouch = Input.GetTouch(0);
            LineMoveCannon();
        }
    }
  
    void LineMoveCannon()
    {
        if (isTouch.phase == TouchPhase.Moved)
        {

            float xAxsis = Mathf.Clamp((transform.localPosition.x + isTouch.deltaPosition.x * Time.deltaTime * speed), -2.5f, 2.5f);
            transform.localPosition = new Vector3(xAxsis,
                transform.localPosition.y,
                transform.localPosition.z);
        }
       
    }
}
