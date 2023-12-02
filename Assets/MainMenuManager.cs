using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject LevelSelector, MainMenu,Kontroller;
    public void OpenLevelSelector() {
    MainMenu.SetActive(false);
        LevelSelector.SetActive(true);  
    }
   public void StartToGame(int ChosenLevel)
    {
        SceneManager.LoadScene(ChosenLevel);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void KontrolleriAc() { 
        Kontroller.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void KontrolleriKapat()
    {
        Kontroller.SetActive(false);
        MainMenu.SetActive(true);
    }
}
