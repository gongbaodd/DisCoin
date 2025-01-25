using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewsFeedBubbleController : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro;

    [SerializeField] private NewsModel news;

    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNews(NewsModel news)
    {
        this.news = news;
        textMeshPro.text = news.content;
    }

    public void OnSelected()
    {
        if (news == null)
        {
            Debug.LogError("News is null");
            return;
        }

        gameManager.SelectNews(news.id);
    }
}
