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
    public Text correctText;
    public bool isQuizOver = false;

    private void Start()
    {
        generateQuestion();

    }
    private void Update()
    {
        if (isQuizOver)
        {
            correctText.text = "";
            questionText.text = $"You Scored: {numCorrect}/10";
            options[0].transform.GetChild(0).GetComponent<Text>().text = "You";
            options[1].transform.GetChild(0).GetComponent<Text>().text = "Win!";
            options[2].transform.GetChild(0).GetComponent<Text>().text = "Play Again?";
            options[3].transform.GetChild(0).GetComponent<Text>().text = "";
        }
    }

    public void correct()
    {
        if (!isQuizOver)
            numCorrect += 1; //only updates if quiz still going on
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
        //update score
        correctText.text = $"Correct Answers: {numCorrect}/10";
        //new question
        currentQuestion += 1;

        if (currentQuestion < QnA.Count)
        {
            //set text and answer options for current question
            questionText.text = QnA[currentQuestion].question;
            setAnswers();
        }
        else
        {
            isQuizOver = true;
            Debug.Log("reached end of quiz");
            //advance to next scene
        }

        

        

    }
}
