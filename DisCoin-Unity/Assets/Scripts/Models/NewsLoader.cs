using UnityEngine;
using System.Collections.Generic;

public class NewsLoader : MonoBehaviour
{
    [System.Serializable]
    public class NewsWrapper
    {
        public List<NewsModelData> newsList;
    }

    [System.Serializable]
    public class NewsModelData
    {
        public string id;
        public float lifetime;
        public string content;
        public float effectPoints;
        public DecisionModelData[] decisions;
        public ReactionModelData[] desertReactions;
    }

    [System.Serializable]
    public class DecisionModelData
    {
        public string id;
        public string newsID;
        public string content;
        public float approvalPercentage;
        public float disapprovalPercentage;
        public ReactionModelData[] reactions;
    }

    [System.Serializable]
    public class ReactionModelData
    {
        public string id;
        public string content;
        public string newsID;
        public string decisionID;
        public string value;
    }

    public NewsModel[] LoadNewsModels()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("newsModels");
        if (jsonText == null)
        {
            Debug.LogError("Cannot find newsModels.json in Resources.");
            return null;
        }

        NewsWrapper wrapper = JsonUtility.FromJson<NewsWrapper>($"{{\"newsList\":{jsonText.text}}}");
        List<NewsModel> newsModels = new List<NewsModel>();

        foreach (var data in wrapper.newsList)
        {
            DecisionModel[] decisions = null;
            if (data.decisions != null)
            {
                decisions = new DecisionModel[data.decisions.Length];
                for (int i = 0; i < data.decisions.Length; i++)
                {
                    var decisionData = data.decisions[i];
                    ReactionModel[] reactions = null;
                    if (decisionData.reactions != null)
                    {
                        reactions = new ReactionModel[decisionData.reactions.Length];
                        for (int j = 0; j < decisionData.reactions.Length; j++)
                        {
                            var reactionData = decisionData.reactions[j];
                            reactions[j] = ReactionModel.CreateReactionModel(
                                reactionData.id,
                                reactionData.content,
                                reactionData.newsID,
                                reactionData.decisionID,
                                (ReactionValue)System.Enum.Parse(typeof(ReactionValue), reactionData.value, true)
                            );
                        }
                    }

                    decisions[i] = DecisionModel.CreateDecisionModel(
                        decisionData.id,
                        decisionData.newsID,
                        decisionData.content,
                        decisionData.approvalPercentage,
                        decisionData.disapprovalPercentage,
                        reactions
                    );
                }
            }

            ReactionModel[] desertReactions = null;
            if (data.desertReactions != null)
            {
                desertReactions = new ReactionModel[data.desertReactions.Length];
                for (int i = 0; i < data.desertReactions.Length; i++)
                {
                    var reactionData = data.desertReactions[i];
                    desertReactions[i] = ReactionModel.CreateReactionModel(
                        reactionData.id,
                        reactionData.content,
                        reactionData.newsID,
                        reactionData.decisionID,
                        (ReactionValue)System.Enum.Parse(typeof(ReactionValue), reactionData.value, true)
                    );
                }
            }

            NewsModel newsModel = NewsModel.CreateNewsModel(
                data.id,
                data.lifetime,
                data.content,
                data.effectPoints,
                decisions,
                desertReactions
            );

            newsModels.Add(newsModel);
        }

        return newsModels.ToArray();
    }
}
