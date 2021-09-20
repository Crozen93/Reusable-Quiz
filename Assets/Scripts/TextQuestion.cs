using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextQuestion : QuestionUI
{
    [SerializeField]
    private TMPro.TextMeshProUGUI questionStringText;

    public override void UpdateQuestionInfo(Question question)
    {
        questionStringText.text = question.questionText;
        base.UpdateQuestionInfo(question);
    }
}
