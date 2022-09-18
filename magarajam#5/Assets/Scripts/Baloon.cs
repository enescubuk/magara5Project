using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Baloon : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 originalScale;
    private Vector3 scaleTo;
    void Start()
    {
        originalScale = transform.localScale;
        scaleTo = originalScale * 2;

        transform.DOScale(scaleTo, 2.0f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
