using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour,IDamageable
{
    internal static HealthManager instance;
    UIHpManager uiHP;

    //[SerializeField] Image healthBar;
    [SerializeField] internal float currentHealth, maxHealth, healthRegen;
    //[SerializeField] TMP_Text perhealthBar;

    [Header("iFrames For Take Damage")]
    [SerializeField] GameObject takeDmg;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    void Awake()
    {
        instance = this;
        uiHP = FindAnyObjectByType<UIHpManager>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentHealth = maxHealth;

        PercentHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (currentHealth > 0)
        {
            StartCoroutine(HitEffect());
            StartCoroutine(Invunerability());
        }
        // if health reach to zero we call the die function
        if (currentHealth == 0)
        {
            //Die();
        }
    }

    public void PercentHealthUI()
    {
        //perhealthBar.text = Mathf.Round(currentHealth / maxHealth * 100) + "%";
        uiHP.hpPercent.text = currentHealth.ToString("0") + "%";

        //Debug.Log(currentHealth);

        // getting the percentage of division between current hp and set it in ui health bar
        uiHP.hpBar.fillAmount = currentHealth / maxHealth;
    }

    public void Die()
    {
        //player controller handle it
        Debug.Log("Player is Dead");
        SceneManager.LoadScene("GameOverScene");
    }
    
    IEnumerator HitEffect()
    {
        Debug.Log("hit");
        takeDmg.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        takeDmg.SetActive(false);
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(3, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(3, 8, false);
    }

    public void IncreaseHealth(float amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth;
    }
}

public interface IDamageable
{
    void TakeDamage(float amount);
}

