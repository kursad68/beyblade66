using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlussEnum
{
    addition,
    multiplication
}
public class enemy : MonoBehaviour
{
    Character ch;
    public int Size;
    public bool doRotateEnable;
    [SerializeField]
    private GameObject PrefabGameObject;
    [SerializeField]
    private PlussEnum plussEnumType;
    private int x;
    
    private void Start()
    {
        
        ch = EventManager.OnCharacter.Invoke();

    }
    private void Update()
    {
        DoRotate(doRotateEnable);
    }
    private void DoRotate(bool Do)
    {if(Do==true)
        transform.Rotate(5, 0,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Character>())
        {
            if (plussEnumType==PlussEnum.addition)
            {
                calculateSize(Size);
            }else
                if (plussEnumType==PlussEnum.multiplication)
            {
                Debug.Log(x + " x " + Size + " size " + ch.topFriendly + " top ");
                x = ch.topFriendly * (Size);
                Debug.Log(x);
            
                calculateSize(x);
            }
       
        }
    
    }
    private void calculateSize(int size)
    {
        for (int j = 0; j < size; j++)
        {


            if (ch.SphereSource <= ch.max - 1 && ch.topFriendly<66)
            {
                
                EventManager.OnCharacterCreate.Invoke(PrefabGameObject);

                ch.SphereSource++;
                if (ch.SphereSource == ch.max)
                {
                    ch.SphereSource = 0;
                  
                    ch.different -= 2;
                    EventManager.OnCameraLocation.Invoke(-2f);
                }

            }

        }
    }
}
