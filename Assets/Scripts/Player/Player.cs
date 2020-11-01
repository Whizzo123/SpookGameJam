using UnityEngine;
using System.Collections;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    private int maxHealth;
    public int health;
    public int PlayerHealth
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            healthText.text = "Player Health: " + health + "/" + maxHealth;
        }
    }

    void Start()
    {
        maxHealth = PlayerHealth;
        PlayerHealth = health;
    }

    public void DecreaseHealth(int damage)
    {
        PlayerHealth -= damage;
    }

    void Update()
    {
        if(PlayerHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        FindObjectOfType<LevelManager>().SetCurrentLevel(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("GameOver");
    }

}
