using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public QuestionDataBase questionDataBase;
    private int level;
    private QuestionSet currentQuestonSet;
    private Question currentQueston;
    private int currentQuestionIndex;

    [SerializeField]
    private Transform questionPanel;
    

    private int correctAnswer;
    private void Start()
    {
        level = PlayerPrefs.GetInt("level", 0);
        LoadQuestionSet();
        UseQuestionTemplate(currentQueston.questinType);
    }

    void LoadQuestionSet()
    {
        currentQuestonSet = questionDataBase.GetQuestionSet(level);
        currentQueston = currentQuestonSet.questions[0];
    }

    void UseQuestionTemplate(Question.QuestinType questinType)
    {
        for (int i = 0; i < questionPanel.childCount; i++)
        {
            questionPanel.GetChild(i).gameObject.SetActive(i == (int)questinType);

            if (i == (int)questinType)
            {
                // GameObject template = questionPanel.GetChild(i).gameObject;
                // template.SetActive(true);
                questionPanel.GetChild(i).GetComponent<QuestionUI>().UpdateQuestionInfo(currentQueston);
            }         
        }
    }

    void NextQuestionSet()
    {
        if (level < questionDataBase.qustionSets.Length - 1)
        {
            level++;
            PlayerPrefs.SetInt("level", level);
            LoadQuestionSet();
        }
        else
        {
            //load start menu
        }
    }

    void NextQuestion()
    {
        if (currentQuestionIndex < currentQuestonSet.questions.Count - 1)
        {
            currentQuestionIndex++;
            currentQueston = currentQuestonSet.questions[currentQuestionIndex];
            UseQuestionTemplate(currentQueston.questinType);
        }
        else
        {
            //do score screen stuff
        }
    }

    public void CheckAnswer(string answer)
    {
        if(answer == currentQueston.correctAnswerKey)
        {
            correctAnswer++;
            Debug.Log("That Correct!");
        }

        NextQuestion();
        //next question
        //reset answer options
    }
}
