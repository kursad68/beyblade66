using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishBonusCube : MonoBehaviour
{
    [SerializeField]
    Text text;
    [SerializeField]
    ParticleSystem particleBom;
    int i = 0;
    Character cm;
    void Start()
    {
        cm = EventManager.OnCharacter.Invoke();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CollectableObject>())
        {
            onParticleStart();
            Destroy(other.gameObject);
            i++;
            text.text = "X" + i;
            cm.topFriendly--;
        }
    }
    private void onParticleStart()
    {
        particleBom.Play();

    }
}
