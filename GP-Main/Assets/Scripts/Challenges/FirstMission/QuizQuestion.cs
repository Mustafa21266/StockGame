using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestion
{
    public string questionText;

    public List<string> answers;
    public int correctAnswerIndex;
    public bool isAnswered = false;
    public string playerAnswer;


    public QuizQuestion(string questionText,List<string> answers, int correctAnswerIndex)
    {
        this.questionText = questionText;
        this.correctAnswerIndex = correctAnswerIndex;
        this.answers = answers;
    }

    public void changeQuestionStatus(){
        this.isAnswered = !this.isAnswered;
    }
}
