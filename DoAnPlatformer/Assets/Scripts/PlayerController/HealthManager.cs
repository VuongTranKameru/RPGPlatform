using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour,IDamageable
{
    internal static HealthManager instance;
    UIHpManager uiHP;

    //[SerializeField] Image healthBar;
    [SerializeField] internal float currentHealth, maxHealth, healthRegen;
    //[SerializeField] TMP_Text perhealthBar;

    void Awake()
    {
        instance = this;
        uiHP = FindAnyObjectByType<UIHpManager>();
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

        // if health reach to zero we call the die function
        if (currentHealth == 0)
        {
            Die();
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
        Debug.Log("Player is Dead");
    }
}

public interface IDamageable
{
    void TakeDamage(float amount);
}

