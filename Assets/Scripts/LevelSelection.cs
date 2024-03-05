using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    
    public void Level1()
    {
       SceneManager.LoadScene(2);
    }

    public void Level2() 
    {
        SceneManager.LoadScene(3);
    }

    public void Level3()
    {
        SceneManager.LoadScene(4);
    }

    public void Back() 
    { 
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
