using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ExtractionEnum
{
    subtraction,
    division
}
public class EnemyGround : MonoBehaviour
{
    Character ch;
    public int DestroyFriendObstacle;
    private int x;
    public ExtractionEnum enumType;
    bool isTriger;
    private void Start()
    {
        isTriger = false;
        ch = EventManager.OnCharacter.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Character>()&&isTriger==false)
        {
            Debug.Log(isTriger);
            isTriger = true;
            Debug.Log(DestroyFriendObstacle+ ""+ isTriger);
            if (enumType == ExtractionEnum.subtraction) {
                
                EventManager.OnDeleteFriendly.Invoke(DestroyFriendObstacle);
            }
           else if (enumType == ExtractionEnum.division)
            {
                x = ch.topFriendly / DestroyFriendObstacle;
                Debug.Log(x);
                EventManager.OnDeleteFriendly.Invoke(x);
                isTriger = true;
            }
            if (ch.topFriendly > 0)
            {
        
            }
            else
            {
                EventManager.OnGameEnd.Invoke();
                ch.sens = 0;
                ch.speed = 0;
            }
        }
    }
}
