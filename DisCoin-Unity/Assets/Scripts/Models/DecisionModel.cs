using UnityEngine;

/*
class Decision {
	id
	newsID
	content
	List<Reaction>
	approvalPercentage
	disapprovalPercentage
}
*/

public enum DecisionType
{
    DISMISS,
    DISMAY,
    DISTORT,
    DISTRACT,
    TRUTH
}

[CreateAssetMenu(fileName = "DecisionModel", menuName = "Scriptable Objects/DecisionModel")]
public class DecisionModel : ScriptableObject
{
    public string id;
    public string newsID;
    public string content;
    public float approvalPercentage;
    public float disapprovalPercentage;

    public DecisionType label;
    public ReactionModel[] reactions;

    static public DecisionModel CreateDecisionModel(string id, string newsID, string content, float approvalPercentage, float disapprovalPercentage, ReactionModel[] reactions, DecisionType label)
    {
        DecisionModel decision = ScriptableObject.CreateInstance<DecisionModel>();
        decision.id = id;
        decision.newsID = newsID;
        decision.content = content;
        decision.approvalPercentage = approvalPercentage;
        decision.disapprovalPercentage = disapprovalPercentage;
        decision.reactions = reactions;
        decision.label = label;
        return decision;
    }
}
