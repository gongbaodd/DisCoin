using UnityEngine;
using TMPro;


public class DecisionCardController : MonoBehaviour
{
    public TMP_Text textMeshPro;

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
}
