using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnim;


    public void RunAnimationTure()
    {
        playerAnim.SetBool("runig", true);
    }
    public void RunAnimationFalse()
    {
        playerAnim.SetBool("runig", false);
    }
    public void FiringAnimationTrue()
    {
        playerAnim.SetBool("fire", true);
    }
    public void FiringAnimationFalse()
    {
        playerAnim.SetBool("fire", false);
    }

    public void idleAnimationTrue()
    {
        playerAnim.SetBool("idle", true);
    }
    public void idleAnimationFalse()
    {
        playerAnim.SetBool("idle", false);
    }
}
