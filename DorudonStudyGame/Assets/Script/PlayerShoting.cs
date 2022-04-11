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
    [SerializeField] int objeckPoolCount;
    private GameObject[] objectPoolBullet;
    public static bool isFire;
    private float fireRare;
    private int poolCounter;
    private int bulletConut;

    private void Start()
    {
        isFire = false;
        bulletConut = 20;
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
    public void Shoting(bool isTrunEnemy, GameObject enemy)
    {
       
        if (isTrunEnemy && bulletConut > 0)
        {
            playerAnimation.idleAnimationFalse();
            playerAnimation.FiringAnimationTrue();
            if (Time.time > fireRare)
            {
                bulletConut--;

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
        if (bulletConut<=0)
        {
            playerAnimation.idleAnimationTrue();
            playerAnimation.FiringAnimationFalse();
        }

    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {

            LockRotate(isFire, other.gameObject);
            Shoting(isFire, other.gameObject);

        }


    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("cephane"))// teg mermi oldugu için çıkartma yapmıyordu
        //{
        //    bulletConut++;
        //}
    }
}
