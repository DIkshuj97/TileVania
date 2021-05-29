using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{
    [SerializeField]
    public float _speed = 5f;

    [SerializeField]
    public float climbspeed = 5f;

    [SerializeField]
    public float jumpspeed = 5f;

    [SerializeField]
    Vector2 deathkick = new Vector2(25f, 25f);

    int arrow=4;

    [SerializeField]
    AudioClip jumpsfx;

   public bool isalive = true;
    public bool isAttack = false;

    Animator myanimator;
    CapsuleCollider2D myBodycollider;
    BoxCollider2D myfeetcollider;
    Rigidbody2D myrigidbody;
    float gravityscale;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        myBodycollider = GetComponent<CapsuleCollider2D>();
        myfeetcollider = GetComponent<BoxCollider2D>();
        gravityscale = myrigidbody.gravityScale; 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isalive) { return; }
        run();
        flip();
        jump();
        Climbladder();
        die();
    }

    //run is used for player movement
    private void run()
    {
        float controlthrow = CrossPlatformInputManager.GetAxis("Horizontal"); 
        Vector2 playervelocity = new Vector2(controlthrow * _speed, myrigidbody.velocity.y);
        myrigidbody.velocity = playervelocity;

        bool playerhashorizontalspeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        myanimator.SetBool("running", playerhashorizontalspeed);
    }

    //flip is used to change the face of player
    private void flip()
    {
        bool playerhashorizontalspeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        if(playerhashorizontalspeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrigidbody.velocity.x),1f);
        }
    }

    private void Climbladder()
    {
        if (!myfeetcollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myanimator.SetBool("climbing", false);
            myrigidbody.gravityScale = gravityscale;
            return;
        }

        float controlThrow =  CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbvelocity = new Vector2(myrigidbody.velocity.x, controlThrow * climbspeed);
        myrigidbody.velocity = climbvelocity;
        myrigidbody.gravityScale = 0f;

        bool playerhasverticalspeed = Mathf.Abs(myrigidbody.velocity.y) > Mathf.Epsilon;
        myanimator.SetBool("climbing", playerhasverticalspeed);
    }

    private void jump()
    {
        if(!myfeetcollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (Input.GetButtonDown("Jump") || CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            AudioSource.PlayClipAtPoint(jumpsfx, Camera.main.transform.position);
            Vector2 jumpvelocity = new Vector2(0f, jumpspeed);
            myrigidbody.velocity += jumpvelocity;
        }
    }

    private void die()
    {
        if (myBodycollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        { 
            isalive = false;
            myanimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathkick;
            FindObjectOfType<GameSession>().playerprocesslives();
        }
    }

    
}
