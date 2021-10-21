using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swerve;
public class Character : MonoBehaviour
{
    public int SphereSource = 0,max;//diff use script
    public int different;//diff use script
    public int topFriendly,topball;//diff use script
    public int speed,sens;//diff use script
    public bool finish,cor;
    public Material material;
    [SerializeField]
    private GameObject sourceFirst, sourceSecond,beybladeObject,SphereSourceObject;
    [SerializeField]
    private Transform deletedObject;

    void Start()
    {
        max = 6;
        different = 0;
        topFriendly = beybladeObject.transform.childCount;
        speed = 3;
        sens = 1;
    }
    private void OnEnable()
    {
        EventManager.OnCharacter += ch;
        EventManager.OnCharacterCreate += CreateFriendly;
        EventManager.OnDeleteFriendly += DeleteFriendly;
        EventManager.Onfinish.AddListener(ShotFriendlyBall);
    }
    private void OnDisable()
    {
        EventManager.OnCharacter -= ch;
        EventManager.OnCharacterCreate -= CreateFriendly;
        EventManager.OnDeleteFriendly-=DeleteFriendly;
        EventManager.Onfinish.RemoveListener(ShotFriendlyBall);

    }
    Character ch()
    {
        return GetComponent<Character>();
    }
    // Update is called once per frame
    void Update()
    {
        if (topFriendly == 0)
        {
            SphereSource = 0;
            different = 0;
        }
        if (finish == true&&cor==false)
        {
            StopCoroutine("ShotTimeBall");
            Debug.Log("cor bitti");
            cor = true;
    
        }
      
        Swerve.SwerveController.MoveOnLine(transform, 10f*speed);
        Swerve.SwerveController.MoveAndRotateOnAxis(transform, 7f, false, true, false, EnumHolder.Axis.x, sens, 30f, 5f);
    }
    private void CreateFriendly(GameObject other)
    {
        topFriendly = beybladeObject.transform.childCount;
        if (topFriendly < 66)//66 is max ball
        {
            GameObject Friendly = Instantiate(other, other.transform.position, Quaternion.identity);
            Friendly.gameObject.transform.position = SphereSourceObject.transform.GetChild(SphereSource).transform.position;
            Friendly.transform.position = new Vector3(Friendly.transform.position.x, Friendly.transform.position.y - different, Friendly.transform.position.z);
            Friendly.transform.SetParent(beybladeObject.transform);
            Friendly.gameObject.GetComponent<MeshRenderer>().material = material;
        }
        topFriendly = beybladeObject.transform.childCount;
        topball = topFriendly;
     
       
    }

    private void DeleteFriendly(int deger)
    {
        
        for (int j = 0; j < deger; j++)
        {
            Debug.Log("silindi");
           
            if (SphereSource >= 0)
            {

                SphereSource--;
                if (SphereSource < 0)
                {
                    SphereSource = max-1;
                    different += 2;
                    EventManager.OnCameraLocation.Invoke(2f);
                }
            }
            if (topFriendly > 0)
            {
                beybladeObject.transform.GetChild(topFriendly - 1).transform.position = new Vector3(0, 0, 0);
               beybladeObject.transform.GetChild(topFriendly - 1).transform.SetParent(deletedObject);
                topFriendly--;
            }
            else
            {
                SphereSource = 0;
                different = 0;

            }
        }
        topFriendly = beybladeObject.transform.childCount;
        topball = topFriendly;

    }
    private void ShotFriendlyBall()
    {
        speed = 0;
        sens = 0;
    topball= beybladeObject.transform.childCount;
    StartCoroutine("ShotTimeBall",topball);
     
    }
    IEnumerator ShotTimeBall(int topball)
    {
        if (topball > 0)
        {
            GameObject BallObject;
            BallObject = beybladeObject.transform.GetChild(topball - 1).gameObject;

            yield return new WaitForSecondsRealtime(0.2f);

            ShotBAll(BallObject);
            topball--;
            StartCoroutine("ShotTimeBall",topball);      
        }
        else
        {
            finish = true;
            EventManager.OnGameEnd.Invoke();
        }
        
    }

    public void ShotBAll(GameObject BallObject)
    {
        Vector3 distance = sourceSecond.transform.position - sourceFirst.transform.position;
        BallObject.transform.position = sourceFirst.transform.position;
        BallObject.AddComponent<Rigidbody>();
        BallObject.GetComponent<Rigidbody>().velocity = distance * 50;
       
       // BallObject.GetComponent<CollectableObject>();
        
        BallObject.transform.parent = null;
    }
}
