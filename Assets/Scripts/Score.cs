using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;
    TextMeshProUGUI scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        score= 0;
        scoreUI= GetComponent<TextMeshProUGUI>();
    }

    void DrawScore()
    {
       scoreUI.text = "score: " +score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        DrawScore();
    }
}
