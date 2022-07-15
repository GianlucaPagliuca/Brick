using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private float speed, x;
    [SerializeField]
    private float maxBallSpeed;
    private GameObject ball, GameManager;
    private Rigidbody2D rb;
    private Vector3 reflectedPosition, movePosition, screenBounds;
    private bool bounced = false;
    // Start is called before the first frame update
    void Start()
    {
        ball = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        float rndX = Random.Range(screenBounds.x * -1, screenBounds.x);
        movePosition = new Vector3(rndX, screenBounds.y * -1, 0);
        GameManager = GameObject.Find("GameManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            switch (collision.name)
            {
                case "Left":
                    x = -1;
                    break;
                case "Right":
                    x = 1;
                    break;
                case "Center":
                    x = 0;
                    break;
                default:
                    x = 0;
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision != null)
        {
            if (collision.gameObject.name == "Brick")
            {
                float height = this.GetComponent<SpriteRenderer>().bounds.size.y / 2;
                this.transform.position = new Vector3(transform.position.x, collision.transform.position.y - height);
            }else if (collision.gameObject.name.Contains("Wall"))
            {
                float size = this.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                float xMult = collision.gameObject.transform.position.x > 0 ? -1 : 1;
                this.transform.position = new Vector3((collision.transform.position.x - size) * xMult, transform.position.y);
            }
                
            float y = transform.position.y > 0 ? 1 : -1;
            if (collision.gameObject.tag != "Player")
                x = screenBounds.x > 0 ? 1 : -1;
            reflectedPosition = Vector3.Reflect(ball.transform.position * 5, new Vector3(x, y));
            bounced = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
        //if (bounced)
        //{
        //    movePosition = reflectedPosition;
        //    bounced = false;
        //}

        //ball.transform.position = Vector3.MoveTowards(ball.transform.position, movePosition, step);

        if (rb.velocity.x > maxBallSpeed || rb.velocity.y > maxBallSpeed || rb.velocity.x < -maxBallSpeed || rb.velocity.y < -maxBallSpeed)
        {
            Vector2 newVelocity = rb.velocity.normalized;
            newVelocity *= maxBallSpeed;
            rb.velocity = newVelocity;
        }

        float ballHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        if(transform.position.y < (screenBounds.y  * -1) + ballHeight)
        {
            GameManager.GetComponent<GameManager>().PlayerDamage();
            Destroy(gameObject);
        }
        Debug.Log(rb.velocity);
    }
}
