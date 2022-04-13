using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] PlayerShoting playerShoting;
    [SerializeField] GameObject [] CapsuleBullet;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==10)
        {
          
            playerShoting.incraseAmnmo();
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
