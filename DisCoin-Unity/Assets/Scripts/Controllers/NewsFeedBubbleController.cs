using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewsFeedBubbleController : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro;
    [SerializeField] private string newsFeedId;

    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text)
    {
        textMeshPro.text = text;
    }

    public void SetNewsFeedId(string id)
    {
        newsFeedId = id;
    }

    public void OnSelected()
    {
        gameManager.SelectNews(newsFeedId);
    }
}
