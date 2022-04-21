using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BulletMove : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbdy;

    IEnumerator EHomingBullet(GameObject enemy, float bulletSpeed, Transform gunBarrel)
    {
        transform.position = gunBarrel.transform.position;
        while (true)
        {
           
            Vector3 axis = enemy.transform.position - transform.position;
            axis.y = 0;
            transform.Translate(axis.normalized * Time.deltaTime * bulletSpeed);
            yield return null;
        }

    }
    public void HomingBullet(GameObject enemy, float bulletSpeed, Transform gunBarrel)
    {
        StartCoroutine(EHomingBullet(enemy, bulletSpeed, gunBarrel));
    }
    public void PunchBullet(float vibaxis)
    {
        transform.GetChild(0).transform.DOPunchPosition(new Vector3(vibaxis, 0, 0), 0.3f, 1);
    }
}
