using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.DOLocalMoveX(0.05f, 0.5f).OnComplete(()=> transform.localPosition=new Vector3(0,transform.localPosition.y,transform.localPosition.z));
        }
    }
}
