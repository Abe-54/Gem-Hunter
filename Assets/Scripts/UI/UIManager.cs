using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<Image> emptyGemUI;
    public Sprite filledGemUI;
    public int numOfGemsCollected;
    public int numOfGemsToCollect;
    public int level;

    private LevelEnding levelEnding;

    // Start is called before the first frame update
    void Start()
    {
        levelEnding = FindObjectOfType<LevelEnding>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (numOfGemsToCollect == numOfGemsCollected)
        {
            levelEnding.levelCompleted[level] = true;
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < emptyGemUI.Count; i++)
        {
           emptyGemUI[numOfGemsCollected-1].sprite = filledGemUI;
        }
    }
}
