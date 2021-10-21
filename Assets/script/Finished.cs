using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Finished : MonoBehaviour
{
    [SerializeField]
    private GameObject FinishSourceObject;
    Character ch;

    private void Start()
    {
        ch = EventManager.OnCharacter.Invoke();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>()&&ch.finish==false)
        {
            ch.sens = 0;
            ch.speed = 0;
            ch.finish = true;
            collision.gameObject.transform.DOMove(FinishSourceObject.transform.position, 1f).OnComplete(() =>
            {
            
                EventManager.Onfinish.Invoke();
                
            });
          
        }
    }
}
