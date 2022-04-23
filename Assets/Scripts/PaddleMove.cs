using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    [SerializeField]/*ц€ штука виводить зм≥ну константи в окреме поле в юн≥т≥*/ float screenWidthInUnit = 16f;
    [SerializeField] float minValue = 0f;
    [SerializeField] float maxValue = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUinits = Input.mousePosition.x /*де знаходитьс€ миша по х*// Screen.width * screenWidthInUnit;
        Vector2 paddlePos = new Vector2(Mathf.Clamp(mousePosInUinits, minValue, maxValue),
            transform.position.y/* ц€ штука закр≥пл€Ї незм≥нн≥сть позиц≥њ по y*/);
        transform.position = paddlePos;
    }
}
