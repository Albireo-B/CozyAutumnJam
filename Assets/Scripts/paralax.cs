using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    [SerializeField] float paralaxMultiplier = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        float xoffset = mousePos.x * paralaxMultiplier;
        float yoffset = mousePos.y * paralaxMultiplier;

        Camera.main.gameObject.transform.position = new Vector3(xoffset, yoffset, Camera.main.transform.position.z);
    }
}
