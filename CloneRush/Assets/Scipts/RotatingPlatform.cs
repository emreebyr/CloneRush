using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 360), 10, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
    }
}
