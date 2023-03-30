using UnityEngine;

public class Ball : MonoBehaviour
{
    //Initial Variables
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 750f;

    //Get the gameObjects rigidbody
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    //Delays the balls flight start
    private void Start()
    {
        Invoke(nameof(RdmTrajectory), 1f);
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
