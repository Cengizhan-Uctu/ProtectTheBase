using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] GameObject ammo;
    [SerializeField] float enemyPeriod;
    [SerializeField] float bulletPeriod;
    private GameObject[] objectPoolEnemy;
    private GameObject[] objectPoolAmmo;
    private int enemyCounter;
    private int ammoCounter;
    void Start()
    {
        objectPoolEnemy = new GameObject[10];
        objectPoolAmmo = new GameObject[10];
        for (int i = 0; i < objectPoolAmmo.Length; i++)
        {
            GameObject newAmmo = Instantiate(ammo);
            newAmmo.SetActive(false);
            objectPoolAmmo[i] = newAmmo;
        }
        for (int i = 0; i < objectPoolEnemy.Length; i++)
        {
            GameObject newEnemy = Instantiate(tower);
            tower.SetActive(false);
            objectPoolEnemy[i] = newEnemy;
        }
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnBullet());
    }

   IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyPeriod);
            objectPoolEnemy[enemyCounter].SetActive(false);
            objectPoolEnemy[enemyCounter].transform.position=transform.position;
            objectPoolEnemy[enemyCounter].SetActive(true);
            enemyCounter++;
            if (enemyCounter == objectPoolEnemy.Length)
            {
                enemyCounter = 0;
            }
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
