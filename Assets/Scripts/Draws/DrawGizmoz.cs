using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmoz : MonoBehaviour
{
    [SerializeField] float mod=1;
    [SerializeField] Color color;
    
    private void OnDrawGizmos()
    {
        color.a = 255f;
        Gizmos.color = color;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x* mod, transform.localScale.y*0.1f,transform.localScale.z* mod));   
    }
}
