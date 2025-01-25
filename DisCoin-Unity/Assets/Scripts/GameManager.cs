using System;
using System.Collections.Generic;
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

    private List<NewsModel> news;

    public List<GameObject> newsFeedBubbles;

    private List<DecisionModel> decisions;

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
        news = new List<NewsModel>(newsModels);  

        for (int i = 0; i < news.Count; i++)
        {
            NewsModel newsModel = news[i];
            GameObject newsFeedBubble = newsFeedBubbles[i];
            NewsFeedBubbleController newsFeedBubbleController = newsFeedBubble.GetComponent<NewsFeedBubbleController>();
            newsFeedBubbleController.SetText(newsModel.content);
            newsFeedBubbleController.SetNewsFeedId(newsModel.id);
            newsFeedBubbles.Add(newsFeedBubble);
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
        decisions = new List<DecisionModel>(newsModel.decisions);

        for (int i = 0; i < decisions.Count; i++)
        {
            DecisionModel decision = decisions[i];
            GameObject decisionCard = decisionCards[i];
            DecisionCardController decisionCardController = decisionCard.GetComponent<DecisionCardController>();
            decisionCardController.SetText(decision.content);
        }
    }
}
