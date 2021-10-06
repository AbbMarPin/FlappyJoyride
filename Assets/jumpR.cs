using UnityEngine;

public class jumpR : MonoBehaviour { 

    public Rigidbody rb;
    public float jump = 10000f;
    public bool jumpPress = false;
    public bool oldjumpPress = false;
    public bool first = true;
    private float timer, y;



    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, jump*Time.deltaTime, 0);
        rb.name = "Player";

    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            // Hover the player before starting the game
            timer += Time.deltaTime;
            y = 40 * Mathf.Sin(3 * timer);
            rb.position = new Vector3(0, y, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
    void FixedUpdate()
    {
        if (GameManager.Instance.GameState()) // playing game...
        {
            if (Input.GetKey("space")) 
            {
                if (first)
                {
                    // Debug.Log("First!!");
                    // This code checks the first tap. After first tap the tutorial image is removed and game starts
                    first = false;
                    GameManager.Instance.GetReady();
                    //GetComponent<Animator>().speed = 2;
                }


                jumpPress = true;
                if (!oldjumpPress)
                {
                    // the cube is going to move upwards in 10 units per second
                    if (rb.position.y < 120)
                        rb.velocity = new Vector3(0, jump, 0);
                    // Debug.Log("jump");
                }
            }
            else
            {
                jumpPress = false;
            }

            oldjumpPress = jumpPress;

            if (rb.position.x < -300 || rb.position.y < -120 )
            {
                GameManager.Instance.GameOver();
            }

        } else
        {
            // game over
            if (Input.GetKey("r"))
            {
                GameManager.Instance.Start();
                rb.position = new Vector3(0, 0, 0);
                rb.velocity = new Vector3(0, 0, 0);
                first = true;
            }



        }

        /*
        if (playerRigid.velocity.y < -1f)
        {
            // Increase gravity so that downward motion is faster than upward motion
            tiltSmooth = maxTiltSmooth;
            playerRigid.gravityScale = 2f;
        }*/
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collition", col);
        var cubeRenderer = col.GetComponent<Renderer>();
        var c = cubeRenderer.material.GetColor("_Color");
        if (c == Color.red)
        {
            if (!first) // playing game...
                GameManager.Instance.GameOver();
        }
    }
}

