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
    }
    private void OnEnable()
    {
        EventManager.OnGameEnd.AddListener(onGameLost);
    }
    private void OnDisable()
    {
        EventManager.OnGameEnd.RemoveListener(onGameLost);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = cM.topFriendly;
        text.text = "Top Ball  " + cM.topFriendly;
         
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(3f);
        buttonGameobject.SetActive(true);
        Time.timeScale = 0;
        SceneWinControl();
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
