using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class save : MonoBehaviour
{

    int[] id = new int[441];
    int[] haveChild = new int[441];
    string[] child = new string[441];

    [SerializeField] EnvirenmentSpawner envirenmentSpawner;
    //[SerializeField] CreateGrid createGrid;

    void Start()
    {
       // SaveFile();
        LoadFile();
    }

    void TakeInfo()
    {
        for(int i=0;i<envirenmentSpawner.gameObjectsGround.Count;i++)
        {
            id[i] = int.Parse(envirenmentSpawner.gameObjectsGround[i].name);
        }
        for (int i = 0; i < envirenmentSpawner.gameObjectsGround.Count; i++)
        {
            if(envirenmentSpawner.gameObjectsGround[i].transform.childCount>=0)
            {
                haveChild[i] = envirenmentSpawner.gameObjectsGround[i].transform.childCount;
            }
            
        }
        for (int i = 0; i < envirenmentSpawner.gameObjectsGround.Count; i++)
        {
            char a = ' ';
            if (envirenmentSpawner.gameObjectsGround[i].transform.childCount > 0)
            {
                a = envirenmentSpawner.gameObjectsGround[i].transform.GetChild(0).name[0];
                child[i] = a.ToString();
            }
        }

    }

    public void SaveFile()
    {
        TakeInfo();
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(id, haveChild, child);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
        print("Save successful");
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();

        id = data.id;
        haveChild = data.haveChild;
        child = data.child;

        SetInfo();
    }
    void SetInfo()
    {
        Vector3 pos = new Vector3(0f, 1.25f, 0f);
        GameObject temp;
        for(int i=0; i<id.Length;i++)
        {
            if(haveChild[i]>0)
            {
                Instantiate(envirenmentSpawner.gameObjectsEnv[int.Parse(child[i])], envirenmentSpawner.gameObjectsGround[i].transform);
                temp = envirenmentSpawner.spawnGround.parentTerrain;
                temp.transform.GetChild(i).gameObject.transform.GetChild(0).transform.localPosition = pos;   //we get parent list of terrain, take selected planes, and give childes position for staying middly on plane;
            }
        }

    }
}