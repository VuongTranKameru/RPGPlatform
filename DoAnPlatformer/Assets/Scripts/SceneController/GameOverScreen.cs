using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject UiScreen;

    [Header("Scoreboard")]
    [SerializeField] GameObject finishBoss;
    [SerializeField] TMP_Text tHp, tStr, tMny, tB, score;
    int tHPPoint, tStrPoint, tMnyPoint, scorePoint;

    internal bool checkBossClear;

    void Start()
    {
        TakePoint();
        CalculateFinalScore();
        score.text = CalculateFinalScore().ToString();
    }

    void TakePoint()
    {
        tHPPoint = (int)HealthManager.instance.maxHealth;
        tHp.text = "+" + tHPPoint.ToString("0");

        tStrPoint = EquipManager.instance.weaponPoint;
        tStr.text = "+" + tStrPoint.ToString();

        tMnyPoint = MoneyManager.instance.gold;
        tMny.text = "+" + tMnyPoint.ToString();

        if (checkBossClear)
        {
            scorePoint = 1000;
            tB.text = "x" + scorePoint.ToString();
            finishBoss.SetActive(true);
        }
    }

    int CalculateFinalScore()
    {
        int ingamePoint = tHPPoint + tStrPoint + tMnyPoint;

        if (!checkBossClear)
            return ingamePoint;

        return ingamePoint * scorePoint;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Scene-IntroTown");
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
