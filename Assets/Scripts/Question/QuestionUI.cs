using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject answerButton;
    [SerializeField]
    private Transform answerPanel;

    public virtual void UpdateQuestionInfo(Question question)
    {
        question.answerChoices = question.answerChoices.OrderBy(answer => Random.value).ToArray();
        foreach (string answer in question.answerChoices)
        {
            Transform answerButtonInstance = Instantiate(answerButton, answerPanel).transform;
            answerButtonInstance.GetComponent<AnswerButton>().SetAnswerButton(answer);
        }
    }
}
