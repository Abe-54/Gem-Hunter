using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Erase : MonoBehaviour
{
    public Tilemap map;
    public RuleTile emptyTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int tilePos = map.WorldToCell(transform.position);
        map.SetTile(tilePos, null);
    }
}
