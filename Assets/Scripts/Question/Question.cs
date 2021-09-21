using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question 
{
    public enum QuestinType {Text = 0, ImageWithCaption = 1, Audio = 2}
    public QuestinType questinType;
    public string questionText;
    public Sprite questionImage;
    public AudioClip qustionAudio;
    public string correctAnswerKey;
    public string[] answerChoices;
}
