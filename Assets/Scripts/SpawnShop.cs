using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnShop : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] LayerMask touchMask;
     CreateGrid createGrid;
    Renderer renderer;
     TextureSwap textureSwap;
    [SerializeField] Camera camera;
    GameObject gameObject;
    GameObject gameObjectSelected;
    [SerializeField]EnvirenmentSpawner envirenmentSpawner;
    [SerializeField] GameObject menu;
    
    void Spawner()
    {
        Vector3 pos = new Vector3(0f,1.25f,0f);
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, touchMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameObject = hit.transform.gameObject;
                createGrid = gameObject.GetComponent<CreateGrid>();
                renderer = gameObject.GetComponent<Renderer>();

                if (createGrid.isEmpty)
                {
                    
                    renderer.material.mainTexture = textureSwap.texture2;
                    Instantiate(gameObjectSelected,gameObject.transform);
                    gameObjectSelected.transform.localPosition = pos;
                    createGrid.isEmpty = false;
                }
                else if (!createGrid.isEmpty)
                {
                    createGrid.isEmpty = true;
                    renderer.material.mainTexture = textureSwap.texture3;
                    
                }
                print("I click on id [" + gameObject.name + "] his coords - X [" + createGrid.X + "], Y [" + createGrid.Y + "], isEmpty [" + createGrid.isEmpty + "]");
            }

        }
    }

    void TakeShopSlot()
    {

    }

}
