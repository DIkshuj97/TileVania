using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   [SerializeField]
    public float speed = 2f;
    Rigidbody2D myrigidbody;
    [SerializeField] GameObject deathVFX;

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFacingRight())
        {
            myrigidbody.velocity = new Vector2(speed, 0f);
        }
        else
        {
            myrigidbody.velocity = new Vector2(-1*speed, 0f);
        }  
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myrigidbody.velocity.x)), 1f);
    }

    public void die()
    {
        TriggerDeathVFX();
        Destroy(gameObject);
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}

