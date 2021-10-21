using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class CameraControl : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera cinemachine;
    CinemachineTransposer cinemachineTransposer;
    private void Start()
    {
        cinemachineTransposer = cinemachine.GetCinemachineComponent<CinemachineTransposer>();
    }
    private void OnEnable()
    {
        EventManager.OnCameraLocation += ChanceLocation;
        EventManager.Onfinish.AddListener(finishCAmera);
  
    }
    private void OnDisable()
    {
        EventManager.OnCameraLocation -= ChanceLocation;
        EventManager.Onfinish.RemoveListener(finishCAmera);
    }
    private void ChanceLocation(float value)
    {
        //  transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + value);
        /* float a = transform.position.z + value/50;
      transform.DOMoveZ(a, 0.5f);*/
        // Debug.Log("girdi"+value);

        // StartCoroutine("softTransiton",value);
        DOTween.To(()=>cinemachineTransposer.m_FollowOffset.z,x=> cinemachineTransposer.m_FollowOffset.z=x, cinemachineTransposer.m_FollowOffset.z+value,1.5f);
        Debug.Log(cinemachineTransposer.m_FollowOffset.z);
    }
    private void finishCAmera()
    {
        cinemachine.Priority = 8;
    }
  /* IEnumerator softTransiton(float value)
    {
        yield return new WaitForSeconds(0.05f);

        if (-value > 0)
        {
            cinemachineTransposer.m_FollowOffset.z -= 0.1f;
            value =value + 0.1f;
            float deger = value;
            Debug.Log(value);
            StartCoroutine(softTransiton(deger));
        }

    }*/
}
