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

[CreateAssetMenu(fileName = "DecisionModel", menuName = "Scriptable Objects/DecisionModel")]
public class DecisionModel : ScriptableObject
{
    public string id;
    public string newsID;
    public string content;
    public float approvalPercentage;
    public float disapprovalPercentage;
    public ReactionModel[] reactions;
}
