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
    [SerializeField]
    private Transform answerPanel;
    [SerializeField]
    private Transform scoreScreen, questionScreen;
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreStats, scorePercentage;

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

    void ClearAnswers()
    {
        foreach (Transform buttons in answerPanel)
        {
            Destroy(buttons.gameObject);
        }
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

    public void NextQuestionSet()
    {
        if (level < questionDataBase.qustionSets.Length - 1)
        {
            correctAnswer = 0;
            currentQuestionIndex = 0; 
            level++;
            PlayerPrefs.SetInt("level", level);            
            scoreScreen.gameObject.SetActive(false);
            questionScreen.gameObject.SetActive(true);
            LoadQuestionSet();
            UseQuestionTemplate(currentQueston.questinType);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
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
            scoreScreen.gameObject.SetActive(true);
            questionScreen.gameObject.SetActive(false);
            scorePercentage.text = string.Format("Score: \n{0}%", (float)correctAnswer/(float)currentQuestonSet.questions.Count * 100);
            scoreStats.text = string.Format("Questions: {0}\nCorrect: {1}", currentQuestonSet.questions.Count, correctAnswer);
        }
    }

    public void CheckAnswer(string answer)
    {
        if(answer == currentQueston.correctAnswerKey)
        {
            correctAnswer++;
            Debug.Log("That Correct!");
        }

        ClearAnswers();
        NextQuestion();
        //next question
        //reset answer options
    }
}
