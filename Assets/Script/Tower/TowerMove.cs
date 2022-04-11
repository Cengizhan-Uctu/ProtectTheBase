using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMove : MonoBehaviour
{
    private void OnEnable()
    {
        int xAxisi = Random.Range(-2, 3);
        transform.position = new Vector3(xAxisi, transform.position.y, 20);
    }

  
    void Update()
    {
        transform.Translate(0, 0, -1 * Time.deltaTime);
    }
}
