using UnityEngine;
public class Target : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    void Start() { currentHealth = maxHealth; }
    public void Hit()
    {
        if (currentHealth <= 0) return;
        currentHealth--;
        if (currentHealth > 0)
            transform.localScale *= 0.9f;
        else
        {
            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
