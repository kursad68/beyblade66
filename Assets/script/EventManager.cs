using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public static class EventManager
{
    public static Func<Character> OnCharacter;
    public static Action<GameObject> OnCharacterCreate;
    public static Action<float> OnCameraLocation;
    public static Action<int> OnDeleteFriendly;
    public static UnityEvent Onfinish = new UnityEvent();
    public static UnityEvent OnGameLost = new UnityEvent();
    public static UnityEvent OnGameWin = new UnityEvent();


}
