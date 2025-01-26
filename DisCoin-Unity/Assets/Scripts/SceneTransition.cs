using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    public GameObject transitionScreen;
    public TMP_Text transitionText;   // Reference to the text element
    public float fadeDuration = 3f;  // Duration of the fade in/out
    public string message = "SIX MONTHS LATER..."; // Transition message
    public string mainSceneName = "MainScene";   // Name of the main scene

    private void Start()
    {

    }

    public void TransitionScene()
    {
        StartCoroutine(ShowTransitionMessage());
    }

    private IEnumerator ShowTransitionMessage()
    {

        transitionScreen.SetActive(true);

        // Set the initial text and make it invisible
        transitionText.text = message;
        transitionText.color = new Color(transitionText.color.r, transitionText.color.g, transitionText.color.b, 0);

        // Fade in
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            transitionText.color = new Color(transitionText.color.r, transitionText.color.g, transitionText.color.b, alpha);
            yield return null;
        }

        // Wait for a moment
        yield return new WaitForSeconds(3f);

        // Fade out
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1 - Mathf.Clamp01(elapsedTime / fadeDuration);
            transitionText.color = new Color(transitionText.color.r, transitionText.color.g, transitionText.color.b, alpha);
            yield return null;
        }

        // Load the main scene
        SceneManager.LoadScene(mainSceneName);
    }
}
