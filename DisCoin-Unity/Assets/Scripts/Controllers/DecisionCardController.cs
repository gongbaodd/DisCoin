using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DecisionCardController : MonoBehaviour
{
    public TMP_Text textMeshPro;
    private GameManager gameManager;
 
    [SerializeField] private GameObject label;

    [SerializeField] private DecisionModel decision;

    [SerializeField] private Sprite dismaySprite;
    [SerializeField] private Sprite dismissSprite;
    [SerializeField] private Sprite distortSprite;
    [SerializeField] private Sprite distractSprite;
    [SerializeField] private Sprite truthSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    public void SetDecision(DecisionModel decision)
    {
        this.decision = decision;
        textMeshPro.text = decision.content;

        switch (decision.label)
        {
            case DecisionType.DISMAY:
                label.GetComponent<Image>().sprite = dismaySprite;
                break;
            case DecisionType.DISMISS:
                label.GetComponent<Image>().sprite = dismissSprite;
                break;
            case DecisionType.DISTORT:
                label.GetComponent<Image>().sprite = distortSprite;
                break;
            case DecisionType.DISTRACT:
                label.GetComponent<Image>().sprite = distractSprite;
                break;
            case DecisionType.TRUTH:
                label.GetComponent<Image>().sprite = truthSprite;
                break;
        }
    }

    public void OnClick()
    {
        if (decision == null)
        {
            Debug.LogError("Decision is null");
            return;
        }
        gameManager.OnDecisionCardClicked(decision.id);
    }
}
