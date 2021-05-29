using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementvector = new Vector2(10f, 10f);
    [SerializeField] float period = 2f;
    // Start is called before the first frame update

    [Range(0, 1)]
    [SerializeField]
    float movementfactor;

    Vector2 startingpos;

    void Start()
    {
        startingpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawsinewave = Mathf.Sin(cycles * tau);

        movementfactor = (rawsinewave / 2f) + 0.5f;
        Vector2 offset = movementfactor * movementvector;
        transform.position = startingpos + offset;
    }

}

