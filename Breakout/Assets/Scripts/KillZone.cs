using UnityEngine;

public class KillZone : MonoBehaviour
{
    //Check for ball going out of bottom bounds to execute code from gamemanager
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            FindObjectOfType<GameManager>().Miss();
        }
    }
}
