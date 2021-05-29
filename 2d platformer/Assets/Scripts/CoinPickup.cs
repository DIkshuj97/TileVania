using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField]
    AudioClip coinsfx;

    [SerializeField]
    int coin = 1;
    bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pickedUp)
        {
            pickedUp = true;
            FindObjectOfType<GameSession>().addtocoin(coin);
            AudioSource.PlayClipAtPoint(coinsfx, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
