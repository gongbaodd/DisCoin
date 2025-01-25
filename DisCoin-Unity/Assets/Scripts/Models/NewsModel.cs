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

    static public NewsModel CreateNewsModel(string id, float lifetime, string content, float effectPoints, DecisionModel[] decisions, ReactionModel[] desertReactions)
    {
        NewsModel news = ScriptableObject.CreateInstance<NewsModel>();
        news.id = id;
        news.lifetime = lifetime;
        news.content = content;
        news.effectPoints = effectPoints;
        news.decisions = decisions;
        news.desertReactions = desertReactions;
        return news;
    }
}
