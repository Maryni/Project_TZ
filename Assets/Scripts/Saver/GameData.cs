using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int[] id;
    public int[] haveChild;
    public string[] child;

  

    public GameData(int[] idInt,int[] haveChildInt, string[] childString)
    {
        id = idInt;
        haveChild=haveChildInt;
        child=childString;
    }
    public List<GameData> list = new List<GameData>();
}
