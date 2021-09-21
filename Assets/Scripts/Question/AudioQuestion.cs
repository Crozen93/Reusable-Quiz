using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioQuestion : QuestionUI
{
    [SerializeField]
    private TMPro.TextMeshProUGUI questionStringText;
    [SerializeField]
    private AudioClip questionAudio;
    [SerializeField]
    private Button audioPlayButton;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void UpdateQuestionInfo(Question question)
    {
        questionStringText.text = question.questionText;
        questionAudio   = question.qustionAudio;
        base.UpdateQuestionInfo(question);
        audioPlayButton.onClick.AddListener(() => PlayAudio());
    }

    public void PlayAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(questionAudio);
    }
}
