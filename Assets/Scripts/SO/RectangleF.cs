using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/RectangleF")]
public class RectangleF : ScriptableObject
{
    [SerializeField] float top;
    [SerializeField] float right;
    [SerializeField] float bottom;
    [SerializeField] float left;


    public float Left { get { return left; } }
    public float Right { get { return right; } }
    public float Bottom { get { return bottom; } }
    public float Top { get { return top; } }

}
