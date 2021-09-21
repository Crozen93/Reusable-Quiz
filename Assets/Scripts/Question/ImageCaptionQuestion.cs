using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCaptionQuestion : QuestionUI
{
    [SerializeField]
    private TMPro.TextMeshProUGUI questionStringText;
    [SerializeField]
    private Image questionImage;

    public override void UpdateQuestionInfo(Question question)
    {
        questionStringText.text = question.questionText;
        questionImage.sprite = question.questionImage;
        base.UpdateQuestionInfo(question);
    }
}
