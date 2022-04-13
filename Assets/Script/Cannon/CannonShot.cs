using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CannonShot : MonoBehaviour
{
    [SerializeField] float cannonShotTime;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform cannonBarrel;
    [SerializeField] float power;
    [SerializeField] GameObject player;
    [SerializeField] float fireDelay;
    [SerializeField] GameObject parentCannon;
    private float fireRare;
    private GameObject[] objectPoolCannonBullet;
    private int bulletCounter;


    private void Awake()
    {
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
            transform.DOLocalMoveX(0.05f, 0.5f).OnComplete(() => transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z));
            transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), 0.4f)
                .OnComplete(() => transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.1f));
            fireRare = Time.time + fireDelay;
            bulletCounter++;
            if (bulletCounter==objectPoolCannonBullet.Length)
            {
                bulletCounter = 0;
            }
        }
    }
    IEnumerator Shooting()
    {
       
        yield return new WaitForSeconds(cannonShotTime);
        player.SetActive(true);
        parentCannon.SetActive(false);
    }

}