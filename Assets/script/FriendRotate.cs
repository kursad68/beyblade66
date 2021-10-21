using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateEnumType{
    x,y,z
}
public class FriendRotate : MonoBehaviour
{
    public RotateEnumType theRotate;
    private void Start()
    {
        
    }
    private void Update()
    {
        if(theRotate==RotateEnumType.z)
        transform.Rotate(0,0, 3f);
        if (theRotate == RotateEnumType.y)
            transform.Rotate(0, 3f, 0);
        if (theRotate == RotateEnumType.x)
            transform.Rotate(3f, 0, 0);
    }
}
