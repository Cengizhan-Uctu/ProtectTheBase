using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : SingeltonGeneric<PlayerCollision>
{
    [SerializeField] GameObject [] CapsuleBullet;

    #region singelton
    private void Awake()
    {
        MakeSingelton(this);
    }
    #endregion
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==10)
        {
            PlayerShoting.Instance.incraseAmnmo();
            collision.gameObject.SetActive(false);
        }
    }
    public void GlassCapsulBullet(int bulletcount)
    {
        for (int i = 0; i < CapsuleBullet.Length; i++)
        {
            if (i<bulletcount)
            {
               
                CapsuleBullet[i].SetActive(true);
            }
            else
            {
              
                CapsuleBullet[i].SetActive(false);
            }
        }
    }
}
