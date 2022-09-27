using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement player;
    public PlayerHealth health;

    [Header("Repsawn")]
    public Transform spawnPoint;
    public float timeBeforeRespawn;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        player.gameObject.SetActive(false);
        //Player Death Anim
        health.health = health.maxHealth;
        player.gameObject.transform.position = spawnPoint.position;
        player.gameObject.SetActive(true);
    }
}
