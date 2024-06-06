using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public Image healthBar;
    public float currentHealth, maxHealth, healthRegen;
    public TextMeshProUGUI perhealthBar;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        instance = this;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        PercentHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        // getting the percentage of division between current hp and set it in ui health bar
        healthBar.fillAmount = GetPercentage();

        //heal the player depend on our health regeneration rate
        Heal(healthRegen * Time.deltaTime);

        PercentHealthUI();
    }

    public void Heal(float amount)
    {
        // pick the smallest value between two number or more number and set it as value of current health
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        //pick the biggest value between two or more number and set as value of current health
        currentHealth = Mathf.Max(currentHealth - amount, 0.0f);
        if(currentHealth > 0)
        {
            StartCoroutine(Invunerability());
        }
        // if health reach to zero we call the die function
        if (currentHealth == 0)
        {
            Die();
        }

    }

    public void PercentHealthUI()
    {
        perhealthBar.text = Mathf.Round(currentHealth / maxHealth * 100) + "%";
    }


    public float GetPercentage()
    {

        return currentHealth / maxHealth;
    }

    public void Die()
    {
        Debug.Log("Player is Dead");
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8,9,true);
        for(int i = 0;i<numberOfFlashes;i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}



public interface IDamageable
{
    void TakeDamage(float amount);
}

