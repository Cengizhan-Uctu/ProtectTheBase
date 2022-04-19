using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetActive : MonoBehaviour
{
    [SerializeField] float bulletLifeTime;
    private void OnEnable()
    {
        StartCoroutine(BulletLifeTime());
    }
    IEnumerator BulletLifeTime()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(bulletLifeTime);
        gameObject.SetActive(false);
    }
}
