using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
    private bool isDead;

    public int health;
    public int maxHealth = 5;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && !isDead)
        {
            //Destroy(gameObject);
            playerSr.enabled = false;
            playerMovement.enabled = false;

            // checks if player is dead to play game over screen
            isDead = true;
            gameManager.gameOver();
        }
    }

}
