using UnityEngine;

/*
class News {
	id
	lifetime
	content
	effectPoints
	List<Decision>
	DesertReaction: List<Reaction>
}
*/

[CreateAssetMenu(fileName = "NewsModel", menuName = "Scriptable Objects/NewsModel")]
public class NewsModel : ScriptableObject
{
    public string id;
    public float lifetime;
    public string content;
    public float effectPoints;

    public DecisionModel[] decisions;

    public ReactionModel[] desertReactions;
}
