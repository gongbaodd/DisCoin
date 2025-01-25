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

    public List<NewsModel> news;

    public List<GameObject> newsFeedBubbles = new List<GameObject>();

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

        // foreach (NewsModel newsModel in news)
        // {
            // Debug.Log(newsModel.content);
            // GameObject newsFeedBubble = Instantiate(NewsFeedBubblePrefab);
            // NewsFeedBubbleController newsFeedBubbleController = newsFeedBubble.GetComponent<NewsFeedBubbleController>();
            // newsFeedBubbleController.SetText(newsModel.content);
        // }   

        for (int i = 0; i < news.Count; i++)
        {
            NewsModel newsModel = news[i];
            Debug.Log(newsModel.content);
            GameObject newsFeedBubble = newsFeedBubbles[i];
            NewsFeedBubbleController newsFeedBubbleController = newsFeedBubble.GetComponent<NewsFeedBubbleController>();
            newsFeedBubbleController.SetText(newsModel.content);
            newsFeedBubbles.Add(newsFeedBubble);
        }

    
    }

    void OnChangeCoinValue(DateTime timestamp, float value)
    {
        coinValueHistory.Add(timestamp, value);
        currentCoinValue = value;
    }
}
