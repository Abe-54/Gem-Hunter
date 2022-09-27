using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private UIManager UIManager;
    

    // Start is called before the first frame update
    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
        UIManager.numOfGemsCollected += 1;
        UIManager.UpdateUI();
    }
}
