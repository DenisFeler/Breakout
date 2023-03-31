using UnityEngine;

public class Player : MonoBehaviour
{
    //Initial Variables
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;
    public float maxBounceAngle = 80f;

    //Get the gameObjects rigidbody
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPlayer()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
        this.rigidbody.velocity = Vector2.zero;
    }

    //Get the left and right inputs from the player, as well as the movement halt
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.direction = Vector2.right;
        }
        else
        {
            this.direction = Vector2.zero;
        }
    }

    //Constant update function for the player movement as to not cap it to fps
    private void FixedUpdate()
    {
        if (this.direction != Vector2.zero)
        {
            this.rigidbody.AddForce(this.direction * this.speed);
        }
    }

    //Function for calculating the ball bounce depending on its contact point to the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ball reference
        Ball ball = collision.gameObject.GetComponent<Ball>();

        //Ball bounce change
        if (ball != null)
        {
            //Get player and ball data
            Vector3 playerPos = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            //Get contact point and set player width
            float offset = playerPos.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            //Get the Ball angle and top the bounce off to have it always bounce back to the top
            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            //Relative rotation calculation given be the angle, for a responsive bounce
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;
        }
    }
}
