using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : SingeltonGeneric<PlayerAnimation>
{
    [SerializeField] Animator playerAnim;

    #region singelton
    private void Awake()
    {
        MakeSingelton(this);
    }
    #endregion
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
