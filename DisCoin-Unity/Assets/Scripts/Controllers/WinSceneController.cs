using System.Collections.Generic;
using UnityEngine;

public class WinSceneController : MonoBehaviour
{

    [SerializeField] private List<GameObject> Celebration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in Celebration)
        {
            item.GetComponent<ParticleSystem>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
