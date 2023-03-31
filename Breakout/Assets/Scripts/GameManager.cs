using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Set up references to gameobjects
    public Ball ball { get; private set; }
    public Player player { get; private set; }
    public Brick[] bricks { get; private set; }
    
    //Predefined game variables
    public int level = 1;
    public int score = 0;
    public int lives = 3;
    
    //On level loadup do not destroy the game manager
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    //On game start create the starting instances
    private void Start()
    {
        NewGame();
    }

    //Starting instance of a new game
    private void NewGame()
    {
        this.score = 0;
        
        this.lives = 3;

        LoadLevel(1);
    }

    //Load level function for easy loading of indefinite level, as long as provided
    private void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }

    //Get object references on load
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.player = FindObjectOfType<Player>();
        this.bricks = FindObjectsOfType<Brick>();
    }

    //Reset the ball and player on missing the ball
    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.player.ResetPlayer();
    }

    //Restart the game after losing all the lives
    private void GameOver()
    {
        NewGame();
    }

    //Ball miss cakculation + check for game reset or restart
    public void Miss()
    {
        this.lives--;

        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }

    //Score collection and level completion
    public void Hit(Brick brick)
    {
        this.score += brick.points;
    
        if (BoardClear())
        {
            LoadLevel(this.level + 1);
        }   
    }

    //Check if board is cleared from every brick that is not unbreakable
    private bool BoardClear()
    {
        for (int i = 0; i<this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
        }

        return true;
    }
}
