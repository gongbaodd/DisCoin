using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameOverController : MonoBehaviour
{
    public Animator bubbleAnimator;
    public float delayBeforeCrash = 3.0f;
    [SerializeField] private GameObject _crashImage;

    void Start()
    {
        GameOver();
    }

    public void GameOver()
    {
        bubbleAnimator.SetTrigger("ExpandTrigger");
        //coinSound.Play();
        Invoke("BurstBubble", 3.0f);
    }

    public void BurstBubble()
    {
        bubbleAnimator.SetTrigger("BurstTrigger");
        StartCoroutine(ShowMarketCrash());


    }

    public IEnumerator ShowMarketCrash()
    {
        yield return new WaitForSeconds(delayBeforeCrash);
        _crashImage.SetActive(true);
    }
}