using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VerticalScroll : MonoBehaviour
{
    [SerializeField] public float scrollrate=0.3f;

    private void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(new Vector2(0f,scrollrate*Time.deltaTime));

         
    }
}
