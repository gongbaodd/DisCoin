using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartController : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public GameObject messageBubblePrefab;
    public Transform contentContainer;
    public Message[] messages;
    public float initialDelay = 1f;

    public ScrollRect scrollRect;
    public GameObject continueButton;

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

            //messageBubblePrefab.SetActive(true);
            newBubble.SetActive(true);


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

            // Wait one frame to allow the layout system to update the content size.
            yield return null;

            // Force an immediate layout rebuild to ensure new bubble's size is accounted for.
            Canvas.ForceUpdateCanvases();

            // Scroll to the bottom (verticalNormalizedPosition = 0 means bottom).
            if (scrollRect != null)
            {
                scrollRect.verticalNormalizedPosition = 0f;
            }


            yield return new WaitForSeconds(msg.delayBeforeNext);
        }

        continueButton.SetActive(true);

    }

    public void StartGame()
    {
        sceneTransition.TransitionScene();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("IntroCutscene");
    }
}

[System.Serializable]
public class Message
{
    public string messageText;  // Text of the message
    public bool isPlayerReply;  // Is this the player's message?
    public float delayBeforeNext; // Delay before the next message
}
