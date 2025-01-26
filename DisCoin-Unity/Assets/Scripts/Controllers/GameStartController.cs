using System.Collections;
using TMPro;
using UnityEngine;

public class GameStartController : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public GameObject messageBubblePrefab;
    public Transform contentContainer;
    public Message[] messages;
    public float initialDelay = 1f;

    private void Start()
    {

    }

    public void StartIntro()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        yield return new WaitForSeconds(initialDelay);

        foreach (Message msg in messages)
        {

            GameObject newBubble = Instantiate(messageBubblePrefab, contentContainer);


            TMP_Text bubbleText = newBubble.GetComponentInChildren<TMP_Text>();
            bubbleText.text = msg.messageText;

            messageBubblePrefab.SetActive(true);


            RectTransform bubbleTransform = newBubble.GetComponent<RectTransform>();
            RectTransform containerTransform = contentContainer.GetComponent<RectTransform>();

            if (msg.isPlayerReply)
            {

                bubbleTransform.anchorMin = new Vector2(1, 0);
                bubbleTransform.anchorMax = new Vector2(1, 0);
                bubbleTransform.pivot = new Vector2(1, 0.5f);
                bubbleTransform.anchoredPosition = new Vector2(-containerTransform.rect.width, bubbleTransform.anchoredPosition.y);


                bubbleTransform.localScale = new Vector3(-1, 1, 1);


                bubbleText.rectTransform.localScale = new Vector3(-1, 1, 1);
            }


            yield return new WaitForSeconds(msg.delayBeforeNext);
        }


        StartGame();
    }

    private void StartGame()
    {
        sceneTransition.TransitionScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

[System.Serializable]
public class Message
{
    public string messageText;  // Text of the message
    public bool isPlayerReply;  // Is this the player's message?
    public float delayBeforeNext; // Delay before the next message
}
