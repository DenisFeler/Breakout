using UnityEngine;

public class Ball : MonoBehaviour
{
    //Initial Variables
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 10f;

    //Get the gameObjects rigidbody
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    //Execute the ball reset on start
    private void Start()
    {
        ResetBall();
    }

    //Reset the ball to original position and randomize trajectory on reset and load up
    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.rigidbody.velocity = Vector2.zero;
        
        Invoke(nameof(RdmTrajectory), 1f);
    }

    //Give the ball a fixed speed calculation not relevant to the fps
    private void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
    }

    //Randomizes the balls trajectory upon game start
    private void RdmTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rigidbody.AddForce(force.normalized * this.speed);
    }
}
