using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupLevel : MonoBehaviour
{
    public GameObject level;
    public GameObject newSpawnPoint;
    public LevelEnding levelEnding;

    public Image emptyGem;

    public int gemsInLevel;

    private UIManager UIManager;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            level.SetActive(true);
            LevelSetup(gemsInLevel);
        }
    }

    public void LevelSetup(int gemsToActivate)
    {
        UIManager.numOfGemsToCollect = gemsInLevel;
        gameManager.spawnPoint.position = newSpawnPoint.transform.position;

        for (int i = 0; i < UIManager.emptyGemUI.Count; i++)
        {
            for (int j = 0; j <= gemsToActivate; j++)
            {
                UIManager.emptyGemUI[j].gameObject.SetActive(true);
            }
        }
    }
}
