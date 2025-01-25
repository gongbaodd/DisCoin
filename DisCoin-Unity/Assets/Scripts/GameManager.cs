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

    public List<NewsModel> news = new List<NewsModel>();

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

        NewsLoader newsLoader = new NewsLoader();
        NewsModel[] newsModels = newsLoader.LoadNewsModels();
        Debug.Log("NewsModels: " + newsModels.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnChangeCoinValue(DateTime timestamp, float value)
    {
        coinValueHistory.Add(timestamp, value);
        currentCoinValue = value;
    }
}
