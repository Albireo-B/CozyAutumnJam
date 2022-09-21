using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class flicker : MonoBehaviour
{

    [SerializeField] float range = 0.1f;
    [SerializeField] float duration = 0.15f;

    private float baseIntensity;
    // Start is called before the first frame update
    void Start()
    {
        baseIntensity = GetComponent<Light2D>().intensity;
        StartCoroutine(flickCycle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator flickCycle()
    {
        while (true){
            GetComponent<Light2D>().intensity = baseIntensity + Random.RandomRange(0, range) - range / 2;
            yield return new WaitForSeconds(duration);
        }
        
    }
}
