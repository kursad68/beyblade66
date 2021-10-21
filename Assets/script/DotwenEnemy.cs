using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum TypeEnemy
{
    enemy,
    sledgehammer,
    pendulum
}
public class DotwenEnemy : MonoBehaviour
{
    Sequence sq;
    [SerializeField]
    private int deger;
    public TypeEnemy TypeEnum;
    private void Start()
    {
        if (TypeEnum == TypeEnemy.pendulum)
            DoRotateOnPendulum(deger);
        else if (TypeEnum == TypeEnemy.sledgehammer)
            DoRotateSledgehammer(deger);
    }

    private void DoRotateOnPendulum(int deger)
    {

        transform.DORotate(new Vector3(0, 0, deger), 1f).OnComplete(()=> 
        {
            DoRotateOnPendulum(-deger);
        });
    }
    private void DoRotateSledgehammer(int deger)
    {
        transform.DORotate(new Vector3(0, 0, deger), 1f).SetLoops(-1, LoopType.Yoyo).From();
    }
}
