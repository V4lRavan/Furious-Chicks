using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    
    public void PlayAgain()
    {
       SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Game over");
        Application.Quit();
    }
}
