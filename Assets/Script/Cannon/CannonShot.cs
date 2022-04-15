using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CannonShot : SingeltonGeneric<CannonShot>
{
    private GameObject[] objectPoolCannonBullet;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Spherify;
    [SerializeField] Transform cannonBarrel;
    [SerializeField] float power;
    [SerializeField] float cannonShotTime;
    [SerializeField] float fireDelay;
    private float fireRare;
    private int bulletCounter;

   
    private void Awake()
    {
        MakeSingelton(this);
        objectPoolCannonBullet = new GameObject[10];
        for (int i = 0; i < objectPoolCannonBullet.Length; i++)
        {
            GameObject newBullet = Instantiate(Bullet);
            newBullet.SetActive(false);
            objectPoolCannonBullet[i] = newBullet;
        }
    }
    private void OnEnable()
    {
        StartCoroutine(Shooting());
    }
    private void Update()
    {
        ShotingCannon();
    }
    void ShotingCannon()
    {
        if (Time.time > fireRare)
        {
            
            objectPoolCannonBullet[bulletCounter].SetActive(true);
            objectPoolCannonBullet[bulletCounter].GetComponent<Rigidbody>().velocity = Vector3.zero;
            objectPoolCannonBullet[bulletCounter].transform.position = cannonBarrel.position;
            objectPoolCannonBullet[bulletCounter].GetComponent<Rigidbody>().AddForce(transform.right * power, ForceMode.Impulse);
            Spherify.transform.DOLocalMoveX(0.05f, 0.5f).
                OnComplete(() => Spherify.transform.localPosition = new Vector3(0, Spherify.transform.localPosition.y, Spherify.transform.localPosition.z));
            Spherify.transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), 0.4f)
                .OnComplete(() => Spherify.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.1f));
           
            fireRare = Time.time + fireDelay;
            bulletCounter++;
            if (bulletCounter == objectPoolCannonBullet.Length)
            {
                bulletCounter = 0;
            }
        }
    }
    IEnumerator Shooting()
    {

        yield return new WaitForSeconds(cannonShotTime);
        player.SetActive(true);
        gameObject.SetActive(false);
    }

}