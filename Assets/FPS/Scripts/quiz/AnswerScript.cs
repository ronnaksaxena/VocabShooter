using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if (quizManager.isQuizOver)
        {
            playAgain();
        }
        else if (isCorrect)
        {
            Debug.Log("correct!"); //change to increment score
            quizManager.correct();
        }
        else
        {
            Debug.Log("wrong!");
            quizManager.incorrect();
        }
    }

    void playAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
