using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] public int X;
    [SerializeField] public int Y;
    private int countChild;
    [SerializeField] public bool isEmpty;
    private void Start()
    {
        countChild = parent.transform.childCount;
        CreateAllValue();
        isEmpty = true;
    }
    [ContextMenu("Rename")]
    
    void Rename()
    {
        countChild = parent.transform.childCount;
        for (int i = 0; i < countChild; i++)
        {
            parent.transform.GetChild(i).name = i.ToString();
        }
    }

    
   // [ContextMenu("CreateValues")]
    //void CreateValues()
   // {
    //    countChild = parent.transform.childCount;
    //    int countArray = (int)Mathf.Sqrt(countChild);
    //    int countHalf = countArray / 2;
    //    int middle = (countArray*(countHalf + 1))- countHalf - 1;  
    //    int i = 0;
    //    while(i< countArray / 2)
    //    {
     //       i++;
     //       parent.transform.GetChild(middle - ((countArray) * i)).GetComponent<CreateGrid>().X = -(i);
      //      parent.transform.GetChild(middle + ((countArray) * i)).GetComponent<CreateGrid>().X = (i);
      //      parent.transform.GetChild(middle - i).GetComponent<CreateGrid>().Y = i;
    //        parent.transform.GetChild(middle + i).GetComponent<CreateGrid>().Y = -(i);
    //        print("success Values") ;
    //    }

    //}

    /// <summary>
    /// Get count raw in array, only for unpair array 3x3,5x5,7x7
    /// </summary>
    [ContextMenu("CreateAllValues")]
    void CreateAllValue()
    {
        countChild = parent.transform.childCount;
        int countArray = (int)Mathf.Sqrt(countChild);
        int countHalf = countArray/2;
        int middle = (countArray * (countHalf + 1)) - countHalf - 1; //центр координат X & Y [0;0] = (кол-во * (кол-во /2, с сокращением в большую сторону)) - кол-во /2, с сокращением в меньшую сторону
        int i = 0;
        for (int j = 0; j < countArray; j++)
        {
            for (i=(countArray*j); i < countArray*(j+1); i++)
            {
                // if((countHalf - i)==0) parent.transform.GetChild(i).GetComponent<CreateGrid>().Y = countHalf - i;
                parent.transform.GetChild(i).GetComponent<CreateGrid>().Y = (countHalf - i)+(countArray*j);
                parent.transform.GetChild(i).GetComponent<CreateGrid>().X = (-(countHalf))+j;
                if ((countHalf - i) == 0) parent.transform.GetChild(i).GetComponent<CreateGrid>().Y = 0;
            }
        }
    }
    
}
