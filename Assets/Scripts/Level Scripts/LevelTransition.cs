using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public GameObject virtualCam;
    public int newLevelNumber;

    private LevelEnding levelEnding;
    private UIManager uiManager;

    void Start()
    {
        levelEnding = FindObjectOfType<LevelEnding>();
        uiManager = FindObjectOfType<UIManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !col.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !col.isTrigger)
        {
            levelEnding.levelNumber = newLevelNumber;
            levelEnding.curLevel = newLevelNumber;
            uiManager.level = newLevelNumber;
            virtualCam.SetActive(false);
        }
    }
}
