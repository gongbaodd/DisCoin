using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ReactionController : MonoBehaviour
{

    private GameObject reactionPanel;
    [SerializeField] private TMP_Text reactionText;
    [SerializeField] private TMP_Text decisionText;
    [SerializeField] private GameObject decisionLabel;

    [SerializeField] private Sprite dismaySprite;
    [SerializeField] private Sprite dismissSprite;
    [SerializeField] private Sprite distortSprite;
    [SerializeField] private Sprite distractSprite;
    [SerializeField] private Sprite truthSprite;

    [SerializeField] private GameObject celebrationEffect;
    [SerializeField] private AudioSource celebrationSound;
    [SerializeField] private GameObject bsEffect;

    [SerializeField] private AudioSource bsSound;
    void Awake()
    {
        // Set the instance of GameManager to this instance
        
        reactionPanel = gameObject;
        reactionPanel.SetActive(false);
    }

    public void ShowReaction(DecisionModel decision,ReactionModel reaction)
    {
        reactionPanel.SetActive(true);
        reactionText.text = reaction.content;
        decisionText.text = decision.content;
        switch (decision.label)
        {
            case DecisionType.DISMAY:
                decisionLabel.GetComponent<Image>().sprite = dismaySprite;
                break;
            case DecisionType.DISMISS:
                decisionLabel.GetComponent<Image>().sprite = dismissSprite;
                break;
            case DecisionType.DISTORT:
                decisionLabel.GetComponent<Image>().sprite = distortSprite;
                break;
            case DecisionType.DISTRACT:
                decisionLabel.GetComponent<Image>().sprite = distractSprite;
                break;
            case DecisionType.TRUTH:
                decisionLabel.GetComponent<Image>().sprite = truthSprite;
                break;
        }

        if (reaction.value == ReactionValue.approval)
        {
            celebrationEffect.GetComponent<ParticleSystem>().Play();
            celebrationSound.Play();
        }

        if (reaction.value == ReactionValue.disapproval)
        {
            bsEffect.GetComponent<ParticleSystem>().Play();
            bsSound.Play();
        }

        StartCoroutine(HideReaction());
    }

    IEnumerator HideReaction()
    {
        yield return new WaitForSeconds(3);
        reactionPanel.SetActive(false);
    }

}
