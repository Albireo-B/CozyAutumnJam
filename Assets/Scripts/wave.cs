using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] float length = 10;
    [SerializeField] float speed = 0.001f;

    private float offset = 0;
    private Vector3 basepos = new Vector3(0, 0, 0);
    private float i = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        basepos = go.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        i = (i + speed) % 360;
        offset = Mathf.Cos(i) * length;
        go.transform.position = basepos + new Vector3(0, offset, 0);
    }
}
