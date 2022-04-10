using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion = -1; //index of current question
    public int numCorrect = 0;

    public Text questionText;

    private void Start()
    {
        generateQuestion();

    }

    public void correct()
    {
        numCorrect += 1;
        generateQuestion();
    }

    public void incorrect()
    {
        generateQuestion();
    }

    private void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            //implemented differently, correct answer is also 0 indexed
            if (QnA[currentQuestion].correctAnswer == i) 
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    private void generateQuestion()
    {
        //new question
        currentQuestion += 1;

        //set text and answer options for current question
        questionText.text = QnA[currentQuestion].question;
        setAnswers();

        

    }
}
