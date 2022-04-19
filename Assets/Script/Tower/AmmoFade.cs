using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AmmoFade : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOPunchScale(new Vector3(.4f, 0.4f, .4f), 0.2f);
    }
}
