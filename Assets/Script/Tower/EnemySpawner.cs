using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float EnemyPeriod;
    private GameObject[] objectPoolEnemy;
    private int enemyConter;
    void Start()
    {
        objectPoolEnemy = new GameObject[10];
        for (int i = 0; i < objectPoolEnemy.Length; i++)
        {
            GameObject newEnemy = Instantiate(enemy);
            enemy.SetActive(false);
            objectPoolEnemy[i] = newEnemy;
        }
        StartCoroutine(SpawnEnemy());
    }

   IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(EnemyPeriod);
            objectPoolEnemy[enemyConter].SetActive(false);
            objectPoolEnemy[enemyConter].transform.position=transform.position;
            objectPoolEnemy[enemyConter].SetActive(true);
            enemyConter++;
            if (enemyConter == objectPoolEnemy.Length)
            {
                enemyConter = 0;
            }
        }
       
    }
}
