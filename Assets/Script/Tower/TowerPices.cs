using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPices : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Fadeout());
    }
    IEnumerator Fadeout()
    {
        yield return new WaitForSeconds(1f);
        transform.parent = null;
        gameObject.GetComponent<Collider>().isTrigger = true;
        gameObject.GetComponent<Rigidbody>().mass = 0.3f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dump"))
        {
            transform.parent = other.gameObject.transform;
            gameObject.SetActive(false);
        }
    }
}
