using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Qustions", menuName = "Create Questions", order = 100)]
public class QuestionDataBase : ScriptableObject
{
    public QuestionSet[] qustionSets;


    public QuestionSet GetQuestionSet(int level)
    {
        foreach (QuestionSet qustionSet in qustionSets)
        {
            if (qustionSet.level == level)
            {
                return qustionSet;
            }
        }
        return new QuestionSet();
    }
}

[System.Serializable]
public struct QuestionSet
{
    public int level;
    public List<Question> questions;
}
