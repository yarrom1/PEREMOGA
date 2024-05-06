using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelSystem : MonoBehaviour
{
    public int currentLevel = 1;
    public int experience = 0;
    public int experienceToNextLevel = 100;
    public GameObject levelUpUI;
    public Button[] skillCards;
    private bool isLevelUpScreenActive = false;

    void Update()
    {
        if (isLevelUpScreenActive)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        experience -= experienceToNextLevel;
        experienceToNextLevel = CalculateExperienceRequiredForNextLevel();
        Debug.Log("Level Up! Current level: " + currentLevel);
        ShowLevelUpUI();
    }

    private void ShowLevelUpUI()
    {
        isLevelUpScreenActive = true;
        levelUpUI.SetActive(true);
        foreach (Button skillCard in skillCards)
        {
            skillCard.gameObject.SetActive(true);
        }
    }

    public void ChooseSkill(int skillIndex)
    {
        Debug.Log("Skill chosen: " + skillIndex);
        switch (skillIndex)
        {
            case 0:
                IncreaseBulletDamage(50f);
                break;
            case 1:
                IncreaseFireRate(0.5f);
                break;
            case 2:
                IncreaseSpeed(50f);
                break;
            default:
                Debug.Log("Invalid skill index");
                break;
        }
        levelUpUI.SetActive(false);
        isLevelUpScreenActive = false;
    }

    private void IncreaseBulletDamage(float amount)
    {
        // Находим все объекты Bullet в сцене и увеличиваем их урон
        Bulet[] bullets = FindObjectsOfType<Bulet>();
        foreach (Bulet bullet in bullets)
        {
            bullet.IncreaseDamage(amount);
        }
    }

    private int CalculateExperienceRequiredForNextLevel()
    {
        return 100 + currentLevel * 50;
    }


    private void IncreaseFireRate(float amount)
    {
        // Находим объект Weapon в сцене и увеличиваем его скорость атаки
        shoot weapon = FindObjectOfType<shoot>();
        if (weapon != null)
        {
            weapon.IncreaseFireRate(amount);
        }

    }
    private void IncreaseSpeed(float amount)
    {
        // Находим объект PlayerMovement и увеличиваем его скорость передвижения
        полет полет = FindObjectOfType<полет>();
        if (полет != null)
        {
            полет.IncreaseSpeed(amount);
        }
    }
}