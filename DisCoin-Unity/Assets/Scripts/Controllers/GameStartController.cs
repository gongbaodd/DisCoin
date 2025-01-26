using System.Collections;
using TMPro;
using UnityEngine;

public class GameStartController : MonoBehaviour
{
    public GameObject messageBubblePrefab; // Prefab for chat bubbles
    public Transform contentContainer;     // Vertical Layout Group container
    public Message[] messages;            // Array of chat messages
    public float initialDelay = 1f;       // Delay before the first message

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
            // Create a new chat bubble
            GameObject newBubble = Instantiate(messageBubblePrefab, contentContainer);

            // Set the message text
            TMP_Text bubbleText = newBubble.GetComponentInChildren<TMP_Text>();
            bubbleText.text = msg.messageText;

            messageBubblePrefab.SetActive(true);

            // Handle alignment and flipping for player replies
            RectTransform bubbleTransform = newBubble.GetComponent<RectTransform>();
            RectTransform containerTransform = contentContainer.GetComponent<RectTransform>(); // Access the container's rect transform

            if (msg.isPlayerReply)
            {
                // Player's message (right-aligned)
                bubbleTransform.anchorMin = new Vector2(1, 0); // Anchor to the right
                bubbleTransform.anchorMax = new Vector2(1, 0);
                bubbleTransform.pivot = new Vector2(1, 0.5f);
                bubbleTransform.anchoredPosition = new Vector2(-containerTransform.rect.width, bubbleTransform.anchoredPosition.y); // Add padding

                // Flip the bubble horizontally
                bubbleTransform.localScale = new Vector3(-1, 1, 1);

                // Flip text back to normal
                bubbleText.rectTransform.localScale = new Vector3(-1, 1, 1);
            }

            // Wait for the specified delay before showing the next message
            yield return new WaitForSeconds(msg.delayBeforeNext);
        }

        // Trigger the game start after the chat cutscene
        StartGame();
    }

    private void StartGame()
    {
        // Logic to start the game (e.g., load the next scene or activate gameplay elements)
        Debug.Log("Chat cutscene complete. Starting the game...");
        // SceneManager.LoadScene("MainGameScene"); // Example transition
    }
}

[System.Serializable]
public class Message
{
    public string messageText;  // Text of the message
    public bool isPlayerReply;  // Is this the player's message?
    public float delayBeforeNext; // Delay before the next message
}
