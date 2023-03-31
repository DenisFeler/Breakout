using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Brick : MonoBehaviour
{
    //Sprite renderer according to brick state equaling its health
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states = new Sprite[0];
    public int health { get; private set; }
    //Predetermined object variables
    public int points = 100;
    public bool unbreakable = false;

    //Get the relevant object sprite
    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Execute brick reset script on start
    private void Start()
    {
        ResetBrick();
    }

    //Activate blocks and check for unbreakable state
    public void ResetBrick()
    {
        this.gameObject.SetActive(true);

        if (!unbreakable)
        {
            this.health = this.states.Length;
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }
    }

    //Hit check for unbreakable blocks as well as destroying the blocks on reaching end state
    private void Hit()
    {
        if (unbreakable)
        {
            return;
        }

        this.health--;

        if (this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }

        FindObjectOfType<GameManager>().Hit(this);
    }

    //Collision check for the ball to execute the damage calculation
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }
}