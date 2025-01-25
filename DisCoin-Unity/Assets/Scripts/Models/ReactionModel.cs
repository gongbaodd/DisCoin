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

    static public ReactionModel CreateReactionModel(string id, string content, string newsID, string decisionID, ReactionValue value)
    {
        ReactionModel reaction = ScriptableObject.CreateInstance<ReactionModel>();
        reaction.id = id;
        reaction.content = content;
        reaction.newsID = newsID;
        reaction.decisionID = decisionID;
        reaction.value = value;
        return reaction;
    }
}
