using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
   [SerializeField] AudioClip lifefx;

    bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pickedUp)
        {
            pickedUp = true;
            FindObjectOfType<GameSession>().addtolives();
           AudioSource.PlayClipAtPoint(lifefx, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
