using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string nextLevel;
     Enemy[] enemies;

     void OnEnable()
     {
        enemies = FindObjectsOfType<Enemy>();
     }

    // Update is called once per frame
    void Update()
    {
        if (AreEnemiesDead())
            NextLevel();
        
    }

    void NextLevel()
    {
        Debug.Log("Go to Level" + nextLevel);
        SceneManager.LoadScene(nextLevel);
    }

    bool AreEnemiesDead()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}

