using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvirenmentSpawner : MonoBehaviour
{
    [SerializeField] public  List<GameObject> gameObjectsEnv;
    [SerializeField] public List<GameObject> gameObjectsGround;
    [SerializeField] List<GameObject> gameObjectsMultiply;
    [SerializeField] int[,] arr;
    [SerializeField] public SpawnGround spawnGround;
    [SerializeField]  bool needSpawn;
    [SerializeField]  int countSpawn;
    int countChild;
    CreateGrid createGrid;
    [SerializeField]TextureSwap textureSwap;
    Renderer renderer;


    public void SetValue(float value)
    {
        countSpawn = (int)value;
        needSpawn = true;
    }

    [ContextMenu("GetGround")]
    void GetGround()
    {
        GameObject temp;
        temp = spawnGround.parentTerrain;
        countChild = temp.transform.childCount;
        for (int i = 0; i < countChild; i++)
        {
            gameObjectsGround.Add(temp.transform.GetChild(i).gameObject);
        }

    }

    //[ContextMenu("Arr")]
    //void Arr()
    //{
    //    countChild = spawnGround.countSpawn;
    //    int[,] arr = new int[countChild, 2];
    //    for (int i = 0; i < countChild; i++)
    //    {
    //        arr[i,0] = gameObjectsGround[i].GetComponent<CreateGrid>().X;
    //        arr[i,1] = gameObjectsGround[i].GetComponent<CreateGrid>().Y;
    //    }
    //    print("Arr success");
    //}
    [ContextMenu("SpawnEnv")]
    public void SpawnEnv()
    {
        countChild = spawnGround.countSpawn;
        int[,] arr = new int[countChild, 2];
        for (int i = 0; i < countChild; i++)
        {
            arr[i, 0] = gameObjectsGround[i].GetComponent<CreateGrid>().X;
            arr[i, 1] = gameObjectsGround[i].GetComponent<CreateGrid>().Y;
        }




        Vector3 pos = new Vector3(0f,1.25f,0);
        if(needSpawn)
        {
            for (int i = 0; i < countSpawn; i++)
            {
                int temp1 = Random.Range(0, countChild);
                int temp2 = Random.Range(0, gameObjectsEnv.Count);
                int temp3 = Random.Range(1,3);
                if(temp3>1)
                {
                    GameObject currentTemp = gameObjectsGround[temp1];
                    createGrid = currentTemp.GetComponent<CreateGrid>();
                    for(int j=0; j< countChild; j++)
                    {
                        if (arr[j, 0] == createGrid.X && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);
                        if (arr[j, 1] == createGrid.Y && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);
                        if (arr[j, 0] == createGrid.X + 1 && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);
                        if (arr[j, 1] == createGrid.Y + 1 && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);
                        if (arr[j, 0] == createGrid.X - 1 && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);
                        if (arr[j, 1] == createGrid.Y - 1 && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);
                        if (arr[j, 0] == createGrid.X - 1 && arr[j, 1] == createGrid.Y - 1 && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);
                        if (arr[j, 0] == createGrid.X + 1 && arr[j, 1] == createGrid.Y - 1 && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);
                        if (arr[j, 0] == createGrid.X - 1 && arr[j, 1] == createGrid.Y + 1 && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);
                        if (arr[j, 0] == createGrid.X + 1 && arr[j, 1] == createGrid.Y + 1 && createGrid.isEmpty) gameObjectsMultiply.Add(gameObjectsGround[j]);  //can upgrade a formul, for env 2x2, cuz for 3x3 - that's a best option
                    }
                    if (temp3 == 2)
                    {

                        
                            for (int g = 0; g < 4; g++)
                            {
                                if (gameObjectsMultiply[g].GetComponent<CreateGrid>().isEmpty)
                                {
                                Instantiate(gameObjectsEnv[temp2], gameObjectsMultiply[g].transform);
                                gameObjectsMultiply[g].transform.GetChild(0).transform.localPosition = pos;
                                gameObjectsMultiply[g].GetComponent<CreateGrid>().isEmpty = false;
                                renderer = gameObjectsMultiply[g].GetComponent<Renderer>();
                                renderer.material.mainTexture = textureSwap.texture2;
                               
                                }
                                
                        }
                    }
                    if (temp3 == 3)
                    {
                        
                       for (int g = 0; g < 9; g++)
                       {

                            if (gameObjectsMultiply[g].GetComponent<CreateGrid>().isEmpty)
                            {
                                Instantiate(gameObjectsEnv[temp2], gameObjectsMultiply[g].transform);
                                gameObjectsMultiply[g].transform.GetChild(0).transform.localPosition = pos;
                                gameObjectsMultiply[g].GetComponent<CreateGrid>().isEmpty = false;
                                renderer = gameObjectsMultiply[g].GetComponent<Renderer>();
                                renderer.material.mainTexture = textureSwap.texture2;
                            }
                           
                            
                        }

                    }
                }
                

                createGrid = gameObjectsGround[temp1].GetComponent<CreateGrid>();
                if (createGrid.isEmpty && temp3 == 1)
                {
                        
                        createGrid.isEmpty = false;
                    Instantiate(gameObjectsEnv[temp2], gameObjectsGround[temp1].transform);
                    gameObjectsGround[temp1].transform.GetChild(0).transform.localPosition = pos;
                    renderer = gameObjectsGround[temp1].GetComponent<Renderer>();
                    renderer.material.mainTexture = textureSwap.texture2;
                }
                gameObjectsMultiply.Clear();
            }
        }
        needSpawn = false;
    }
    public void ClearGround()
    {
        
        for(int i=0; i<gameObjectsGround.Count;i++)
        {
            if(gameObjectsGround[i].transform.childCount>0)
            {
                createGrid = gameObjectsGround[i].GetComponent<CreateGrid>();
                Transform tempChild = gameObjectsGround[i].transform.GetChild(0);
                createGrid.isEmpty = true;
                tempChild.gameObject.SetActive(false);
                tempChild.parent = null;
            }
        }

    }

}
