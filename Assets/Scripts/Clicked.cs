using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] LayerMask touchMask;
    RaycastHit hit;
     GameObject gameObject;
    [SerializeField] TextureSwap textureSwap;
     CreateGrid createGrid;
     Renderer renderer;
    GameObject gameObjectSelected;
    [SerializeField] EnvirenmentSpawner envirenmentSpawner;
    [SerializeField] GameObject menu;


    private void FixedUpdate()
    {
        Click();
    }

    public void SelectObject(int a)
    {
        gameObjectSelected = envirenmentSpawner.gameObjectsEnv[a];
        menu.SetActive(false);
    }
    void Click()
    {
        Vector3 pos = new Vector3(0f,1.25f,0f);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, touchMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameObject = hit.transform.gameObject;
                createGrid = gameObject.GetComponent<CreateGrid>();
                renderer = gameObject.GetComponent<Renderer>();
                
                if(createGrid.isEmpty && gameObjectSelected!=null)
                {
                    createGrid.isEmpty = false;
                    renderer.material.mainTexture = textureSwap.texture2;
                    Instantiate(gameObjectSelected, gameObject.transform);
                    gameObject.transform.GetChild(0).transform.localPosition = pos;
                    
                }
                else if(!createGrid.isEmpty)
                {
                    //createGrid.isEmpty = true;
                    //renderer.material.mainTexture = textureSwap.texture2;
                }
                print("I click on id [" + gameObject.name + "] his coords - X [" + createGrid.X + "], Y [" + createGrid.Y + "], isEmpty [" + createGrid.isEmpty + "]");
            }
         
        }
    }
}
