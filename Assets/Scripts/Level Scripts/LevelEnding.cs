using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnding : MonoBehaviour
{
    public GameObject[] Erasers;

    public bool[] levelCompleted;
    public int levelNumber;
    public int curLevel;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (levelCompleted[levelNumber])
        {
            EraseWall(Erasers[levelNumber]);
        }
    }

    public void EraseWall(GameObject levelErasers)
    {
        levelErasers.SetActive(true);
    }
}
