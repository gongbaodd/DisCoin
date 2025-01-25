using UnityEngine;

/*
class Reaction {
	id
	content
	newsID
	DecisionID
	value: approval | disapproval | noEffect
}
*/

public enum ReactionValue
{
    approval,
    disapproval,
    noEffect
}

[CreateAssetMenu(fileName = "ReactionModel", menuName = "Scriptable Objects/ReactionModel")]
public class ReactionModel : ScriptableObject
{
    public string id;
    public string content;
    public string newsID;
    public string decisionID;
    public ReactionValue value;
}
