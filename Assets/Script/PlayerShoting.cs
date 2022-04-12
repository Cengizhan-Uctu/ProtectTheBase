using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerShoting : MonoBehaviour
{
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunBarrel;
    [SerializeField] float rotateSpeed;
    [SerializeField] float fireDelay;
    [SerializeField] float bulletSpeed;
    [SerializeField] float shotRange;
    [SerializeField] int objeckPoolCount;
    [SerializeField] LayerMask enemtLayer;
    [SerializeField] PlayerCollision playerCollision;
    private GameObject[] objectPoolBullet;
    public static bool isFire;
    private float fireRare;
    private int poolCounter;
    private int bulletConut;

    private void Start()
    {
        isFire = false;
        bulletConut = 6;
        playerCollision.GlassCapsulBullet(bulletConut);
        objectPoolBullet = new GameObject[objeckPoolCount];
        for (int i = 0; i < objectPoolBullet.Length; i++)
        {
            GameObject newBullet = Instantiate(bullet);
            bullet.SetActive(false);
            objectPoolBullet[i] = newBullet;
        }
    }

    public void LockRotate(bool isTrunEnemy, GameObject other)
    {
        if (isTrunEnemy)
        {
            Quaternion lookOnLook = Quaternion.LookRotation(other.transform.position - transform.position);
            lookOnLook.z = 0f;
            lookOnLook.x = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, Time.deltaTime * rotateSpeed);
        }

    }
    private void Update()
    {
        oncollision();
       
    }
    public void Shoting(bool isTrunEnemy, GameObject enemy)
    {
       
        if (isTrunEnemy && bulletConut > 0)
        {
           
           
            if (Time.time > fireRare)
            {
                playerAnimation.FiringAnimationTrue();
                bulletConut--;
                if (bulletConut<=0)
                {
                    return;
                }
                playerCollision.GlassCapsulBullet(bulletConut);
                objectPoolBullet[poolCounter].SetActive(true);
                objectPoolBullet[poolCounter].transform.position = gunBarrel.position;
                objectPoolBullet[poolCounter].transform.DOMove(new Vector3(enemy.transform.position.x, enemy.transform.position.y+1, enemy.transform.position.z) , bulletSpeed);
                objectPoolBullet[poolCounter].transform.GetChild(0).transform.DOPunchPosition(new Vector3(1, 0, 0), 3, 2, 3);
                poolCounter++;
                if (poolCounter == objectPoolBullet.Length)
                {
                    poolCounter = 0;
                }

                fireRare = Time.time + fireDelay;
            }
        }

    }
    void oncollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, shotRange);

        foreach (Collider hitcollider in hitColliders)
        {
            if (hitcollider.gameObject.layer == 8)
            {
                LockRotate(isFire, hitcollider.gameObject);
                Shoting(isFire, hitcollider.gameObject);
            }

        }
       
    }
    public void incraseAmnmo() 
    {
        bulletConut++;
        playerCollision.GlassCapsulBullet(bulletConut);
        if (bulletConut>12)
        {
            // top çıkart
        }
    }
   
}
