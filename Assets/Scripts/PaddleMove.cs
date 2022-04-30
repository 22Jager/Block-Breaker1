using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    float screenWidthInUnit = 16f;
    [SerializeField] float minValue = 0f; 
    [SerializeField] float maxValue = 16f;
    
    // Update is called once per frame
    void Update()
    {
        float mousePosInUinits = (Input.mousePosition.x / Screen.width) 
                                 * screenWidthInUnit;
        Vector2 paddlePos = new Vector2(
            Mathf.Clamp(mousePosInUinits, minValue, maxValue),
            transform.position.y);
        transform.position = paddlePos;
    }
}
