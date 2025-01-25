using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
class GameManager {
	currentCoinValue
	poolCount
	holdCount
	Dictionary<Timestamp, value>
	startTime
	List<news>
	playerMoney
}
*/
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance { get; private set; }

    public float currentCoinValue;
    public int poolCount;
    public int holdCount;
    public DateTime startTime;
    public float playerMoney = 0;

    public Dictionary<DateTime, float> coinValueHistory = new Dictionary<DateTime, float>();

    [SerializeField] private List<NewsModel> news = new List<NewsModel>();

    public List<GameObject> newsFeedBubbles;

    [SerializeField] private List<DecisionModel> decisions = new List<DecisionModel>();

    public List<GameObject> decisionCards;

    void Awake()
    {
        // Check if an instance of GameManager already exists
        if (instance != null && instance != this)
        {
            // Destroy this instance if a GameManager already exists
            Destroy(gameObject);
            return;
        }

        // Set this as the instance and make it persistent across scenes
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadNews();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadNews()
    {
        NewsLoader newsLoader = ScriptableObject.CreateInstance<NewsLoader>();
        NewsModel[] newsModels = newsLoader.LoadNewsModels();
        news = newsModels.ToList();
        ShowNews();
        showDecisions();
    }

    void ShowNews()
    {
        for (int i = 0; i < newsFeedBubbles.Count; i++)
        {
            GameObject newsFeedBubble = newsFeedBubbles[i];

            if (news.Count <= i)
            {
                newsFeedBubble.SetActive(false);
                continue;
            }

            newsFeedBubble.SetActive(true);
            NewsFeedBubbleController newsFeedBubbleController = newsFeedBubble.GetComponent<NewsFeedBubbleController>();
            newsFeedBubbleController.SetText(news[i].content);
            newsFeedBubbleController.SetNewsFeedId(news[i].id);
        }
    }

    void OnChangeCoinValue(DateTime timestamp, float value)
    {
        coinValueHistory.Add(timestamp, value);
        currentCoinValue = value;
    }

    public void SelectNews(string newsFeedId)
    {

        NewsModel newsModel = news.Find(news => news.id == newsFeedId);

        decisions = newsModel.decisions.ToList();

        showDecisions();

    }

    void showDecisions()
    {
        for (int i = 0; i < decisionCards.Count; i++)
        {
            if (decisions.Count <= i)
            {
                decisionCards[i].SetActive(false);
                continue;
            } 
            
            decisionCards[i].SetActive(true);

            DecisionModel decision = decisions[i];
            GameObject decisionCard = decisionCards[i];
            DecisionCardController decisionCardController = decisionCard.GetComponent<DecisionCardController>();
            decisionCardController.SetText(decision.content);
            decisionCardController.SetId(decision.id);
        }
    }

    public void OnDecisionCardClicked(string id)
    {
        DecisionModel decision = decisions.Find(decision => decision.id == id);
        NewsModel newsModel = news.Find(news => news.id == decision.newsID);

        if (decision == null)
        {
            Debug.LogError("Decision not found");
            return;
        }

        if (newsModel == null)
        {
            Debug.LogError("News not found");
            return;
        }

        ReactionModel[] reactions = decision.reactions;
        float randomValue = UnityEngine.Random.Range(0f, 1f);

        ReactionValue reactionValue = ReactionValue.noEffect;

        if (randomValue < decision.approvalPercentage/100)
        {
            reactionValue = ReactionValue.approval;
        }
        else if (randomValue < (decision.approvalPercentage + decision.disapprovalPercentage)/100)
        {
            reactionValue = ReactionValue.disapproval;
        }

        if (reactionValue == ReactionValue.noEffect) {
            // no effect on the coin value
            return;
        } 

        if (reactionValue == ReactionValue.approval)
        {
            currentCoinValue += newsModel.effectPoints;
        }
        else if (reactionValue == ReactionValue.disapproval)
        {
            currentCoinValue -= newsModel.effectPoints;
        }
    }
}
