using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnim;


    public void idleAnimationTrue()
    {
        playerAnim.SetInteger("state", 0);
    }
    public void RunAnimationTure()
    {
        playerAnim.SetInteger("state", 1);
    }
  
    public void FiringAnimationTrue()
    {
      
      playerAnim.Play("firing");
    }
   
   
}
