using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class snap : MonoBehaviour
{
    public int XStep = 1;
    public int YStep = 1;
    public int ZStep = 1;
    void Update()
    {
        if (!Application.isPlaying)
        {
            SnapPos();
        }
    }

    void SnapPos()
    {
        int clampedX = Mathf.RoundToInt(transform.position.x) / XStep;
        int clampedY = Mathf.RoundToInt(transform.position.y) / YStep;
        int clampedZ = Mathf.RoundToInt(transform.position.z) / ZStep;
        transform.position = new Vector3(clampedX * XStep, clampedY * YStep, clampedZ * ZStep);
    }

}