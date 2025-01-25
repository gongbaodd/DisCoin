using UnityEngine;
using TMPro;


public class DecisionCardController : MonoBehaviour
{
    public TMP_Text textMeshPro;
    private GameManager gameManager;

    [SerializeField] private DecisionModel decision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SetDecision(DecisionModel decision)
    {
        this.decision = decision;
        textMeshPro.text = decision.content;
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
