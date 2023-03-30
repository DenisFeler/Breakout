using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public int score = 0;
    public int highscore = 0;
    public int lives = 3;
    
    //On level loadup do not destroy the game manager
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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

        //Check if previous highscore was beaten
        if(this.score >= this.highscore)
        {
            this.highscore = this.score;
        }
        else
        {
            this.highscore = this.highscore;
        }
        
        this.lives = 3;

        LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }
}
