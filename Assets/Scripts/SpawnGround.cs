using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    [SerializeField] GameObject prefabTerrain;
    [SerializeField] public GameObject parentTerrain;
    [SerializeField] public int countSpawn;
    
    void Start()
    {
        Spawn();   
    }

    void Spawn()
    {
        //for(int i=0;i<countSpawn;i++)
        //{
        //    Instantiate(prefabTerrain, parentTerrain.transform);
        //}
        
    }
}
