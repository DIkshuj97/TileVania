using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKill : MonoBehaviour
{
    bool killed = false;
    
    [SerializeField] AudioClip EnemyKilledfx;

    private void OnTriggerStay2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.GetComponent<player>())
        {
            if (!killed)
            {
                killed = true;
                
                FindObjectOfType<GameSession>().EnemyKilledAdd();
                AudioSource.PlayClipAtPoint(EnemyKilledfx, Camera.main.transform.position);
                GetComponentInParent<EnemyMovement>().die();
            }
        }
    }

    
}




        
        


