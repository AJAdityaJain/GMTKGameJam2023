using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public ClickableBehaviour active = null;
    private void Update()
    {
        if(active == null)
        {
            return;
        }   
        var inp = Input.GetAxis("Horizontal");
        if(inp > 0)
        {
            active.Right(Mathf.Abs( inp));
        }
        else if(inp < 0)
        {
            active.Left(Mathf.Abs(inp));
        }
    }
}
