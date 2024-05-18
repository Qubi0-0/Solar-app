using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch detected. Touch count: " + Input.touchCount);
        }
        else
        {
            Debug.Log("No touch detected.");
        }
    }
}
