using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class PlayerLevelSystem : MonoBehaviour
{
    public int currentLevel = 1;
    public int experience = 0;
    public int expM = 1;
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
        experience += amount*expM;
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

    
    // В методе ShowLevelUpUI() заменим skillCards на skillIndex
    private void ShowLevelUpUI()
    {
        isLevelUpScreenActive = true;
        levelUpUI.SetActive(true);

        // Сначала деактивируем все карточки скиллов
        foreach (Button skillCard in skillCards)
        {
            skillCard.gameObject.SetActive(false);
        }

        // Получаем случайное количество карточек для отображения
        int numCardsToShow = 3; 

        // Создаем список индексов и заполняем его
        List<int> indices = new List<int>();
        for (int i = 0; i < skillCards.Length; i++)
        {
            indices.Add(i);
        }

        // Перемешиваем список индексов
        for (int i = 0; i < indices.Count; i++)
        {
            int temp = indices[i];
            int randomIndex = UnityEngine.Random.Range(i, indices.Count);
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        // Отображаем случайные карточки
        for (int i = 0; i < numCardsToShow; i++)
        {

            skillCards[indices[i]].gameObject.SetActive(true);
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
            case 3:
                IncreaseHP(50f);
                break;
            case 4:
                Exp(1);
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

    private void Exp(int amount)
    {
        expM += amount;

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
    private void IncreaseHP(float amount)
    {
        // Находим объект PlayerMovement и увеличиваем его скорость передвижения
        Enemy полет = FindObjectOfType<Enemy>();
        if (полет != null)
        {
            полет.IncreaseHP(amount);
        }
    }
}