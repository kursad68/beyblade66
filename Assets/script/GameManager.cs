using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    Character cM;
    [SerializeField]
    GameObject buttonGameobject;
    [SerializeField]
    Text text;
    bool isGameEnd;
    void Start()
    {
        text.text = "Top Ball : 0";
        isGameEnd = false;
        slider.value = 0;
        cM = EventManager.OnCharacter.Invoke();
        buttonGameobject.SetActive(false);
        Time.timeScale = 1;
        cM.speed = 0;
        cM.sens = 0;
    }
    private void OnEnable()
    {
        EventManager.OnGameLost.AddListener(onGameLost);
        EventManager.OnGameWin.AddListener(()=> { SceneWinControl(); onGameLost(); 
        });
    }
    private void OnDisable()
    {
        EventManager.OnGameLost.RemoveListener(onGameLost);
        EventManager.OnGameWin.RemoveListener(SceneWinControl);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&isGameEnd==false)
        {
            isGameEnd = true;
            cM.speed = 3;
            cM.sens = 1;

        }

        slider.value = cM.topFriendly;
        text.text = "Top Ball  " + cM.topFriendly;
         
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1.5f);
        buttonGameobject.SetActive(true);
        Time.timeScale = 0;
       
    }
    private void onGameLost()
    {
        StartCoroutine(enumerator());
    }
    public void onclick()
    {
        SceneManager.LoadScene(0);
    }
    private void SceneWinControl()
    {
     
      
            int temp;
            temp = PlayerPrefs.GetInt("CurrentLevel");
            temp++;
            PlayerPrefs.SetInt("CurrentLevel", temp);
            Debug.Log("new level " + temp + " " + PlayerPrefs.GetInt("CurrentLevel"));
           
       
    }
}
