using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
     int score =0;

     public void updateScore(int amount){
        score+=amount;
        Debug.Log($"Your Score:{score}");
        scoreText.SetText(score.ToString());   
     }
}
