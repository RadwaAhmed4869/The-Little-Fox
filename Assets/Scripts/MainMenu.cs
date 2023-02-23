using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text scoreTxt;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PlayerLevel"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    void OnEnable()
    {
        
        score = PlayerPrefs.GetInt("GemsCount");
        scoreTxt.text = "Gems: " + score;
    }


}
