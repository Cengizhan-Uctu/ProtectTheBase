using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerShoting : SingeltonGeneric<PlayerShoting>
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject cannon;
    [SerializeField] Transform gunBarrel;
    [SerializeField] float rotateSpeed;
    [SerializeField] float fireDelay;
    [SerializeField] float bulletSpeed;
    [SerializeField] float shotRange;
    [SerializeField] int objeckPoolCount;
    [SerializeField] int maxBullet;
    public static bool isFire;
    private float fireRare;
    private int bulletConut;
    private float vibaxis = 2f;
    int shotCounter;
    #region singelton
    private void Awake()
    {
        MakeSingelton(this);
    }
    #endregion
    private void Start()
    {
        isFire = false;
        bulletConut = 60;
        PlayerCollision.Instance.GlassCapsulBullet(bulletConut);
       
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
        int towerHealt = enemy.GetComponent<TowerExplosion>().maxHealt;
        if (isTrunEnemy && bulletConut > 0&&shotCounter<towerHealt)
        {
            if (Time.time > fireRare)
            {
               
                PlayerAnimation.Instance.FiringAnimationTrue();
                bulletConut--;
                PlayerCollision.Instance.GlassCapsulBullet(bulletConut);
                GameObject newBullet = Instantiate(bullet, gunBarrel.transform.position, Quaternion.identity);
                newBullet.GetComponent<BulletMove>().HomingBullet(enemy, bulletSpeed, gunBarrel.transform);
                newBullet.GetComponent<BulletMove>().PunchBullet(vibaxis);
                vibaxis *= -1;
                shotCounter++;
                fireRare = Time.time + fireDelay;
            }
          
        }

    }

    void oncollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, shotRange);

        foreach (Collider hitcollider in hitColliders)
        {
            if (hitcollider.gameObject.CompareTag("Enemy"))
            {
                LockRotate(isFire, hitcollider.gameObject);
                Shoting(isFire, hitcollider.gameObject);
            }

        }

    }
    public void incraseAmnmo()
    {
        bulletConut += 10;
        PlayerCollision.Instance.GlassCapsulBullet(bulletConut);
        if (bulletConut > maxBullet)
        {
            bulletConut -= 5;
            cannon.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}