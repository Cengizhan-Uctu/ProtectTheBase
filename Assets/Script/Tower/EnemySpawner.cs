using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SingeltonGeneric<EnemySpawner>
{
    [SerializeField] GameObject tower;
    [SerializeField] GameObject ammo;
    [SerializeField] float enemyPeriod;
    [SerializeField] float bulletPeriod;
    private GameObject[] objectPoolAmmo;
    private int enemyCounter;
    private int ammoCounter;

    #region singelton
    private void Awake()
    {
        MakeSingelton(this);
    }
    #endregion
    void Start()
    {
       
        objectPoolAmmo = new GameObject[10];
        for (int i = 0; i < objectPoolAmmo.Length; i++)
        {
            GameObject newAmmo = Instantiate(ammo);
            newAmmo.SetActive(false);
            objectPoolAmmo[i] = newAmmo;
        }
      
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnBullet());
    }

   IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyPeriod);
            Instantiate(tower,transform.position,Quaternion.identity);
           
        }
       
    }
    IEnumerator SpawnBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletPeriod);
            float randomx = Random.Range(-2,3);
            float randomz = Random.Range(-1, 3);
            objectPoolAmmo[ammoCounter].SetActive(false);
            objectPoolAmmo[ammoCounter].transform.position = new Vector3(randomx,0.65f,randomz);
            objectPoolAmmo[ammoCounter].SetActive(true);
            ammoCounter++;
            if (ammoCounter == objectPoolAmmo.Length)
            {
                ammoCounter = 0;
            }
        }

    }
}
