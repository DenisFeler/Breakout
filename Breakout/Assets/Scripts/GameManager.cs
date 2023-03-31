using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Player player { get; private set; }
    public Brick[] bricks { get; private set; }
    
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

    private void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.player = FindObjectOfType<Player>();
        this.bricks = FindObjectsOfType<Brick>();
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.player.ResetPlayer();
    }

    private void GameOver()
    {
        NewGame();
    }

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

    public void Hit(Brick brick)
    {
        this.score += brick.points;
    
        if (BoardClear())
        {
            LoadLevel(this.level + 1);
        }   
    }

    private bool BoardClear()
    {
        for (int i = 0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
        }

        return true;
    }
}
