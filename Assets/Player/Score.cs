using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public float CurrentScore;
    public string ScoreDisplay() {return Mathf.RoundToInt(CurrentScore).ToString();}

    void Update()
    {
        CurrentScore += Time.deltaTime;

        ScoreText.text = ScoreDisplay();
    }
}
