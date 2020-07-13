using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwap : MonoBehaviour
{
    [SerializeField] public Texture texture1;
    [SerializeField] public Texture texture2;
    [SerializeField] public Texture texture3;
    [SerializeField] public Texture texture4;
    [SerializeField] SpawnGround spawnGround;
    [SerializeField] GameObject parent;
    public bool clicked;

    /// <summary>
    /// Swap visibility of coords, using swap textures
    /// </summary>
    [ContextMenu("ChangeTexture")]
    public void ChangeTexture()
    {
        int count = spawnGround.countSpawn;
        for(int i = 0; i< count; i++)
        {
            if (parent.transform.GetChild(i).transform.childCount == 0)
            {
                parent.transform.GetChild(i).GetComponent<Renderer>().material.mainTexture = texture3;
            }
            else
            {
                parent.transform.GetChild(i).GetComponent<Renderer>().material.mainTexture = texture2;
            }
        }
        ReserTextures();
    }
     void ReserTextures()
    {
        int count = spawnGround.countSpawn;
        if(clicked)
        {
            for (int i = 0; i < count; i++)
            {
                if (parent.transform.GetChild(i).transform.childCount == 0)
                {
                    parent.transform.GetChild(i).GetComponent<Renderer>().material.mainTexture = texture4;
                }
            }
            clicked = false;
            return;
        }
        clicked = true;
        

    }
   
}
