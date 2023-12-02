using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject WinPage,LosePage;
    [SerializeField] GameObject[] Enemies;
    public bool Won,Lost;
    public void Update()
    {
        Won = true;
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Enemies[i].activeSelf)
            {
                Won = false;
            }
        }
        if (Won&&!WinPage.activeSelf)
        {
            Winning();
        }
    }
    public void Winning()
    {
        Time.timeScale = 0;
        WinPage.SetActive(true);
    }
    public void Losing()
    {
        Time.timeScale = 0;
        LosePage.SetActive(true);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
