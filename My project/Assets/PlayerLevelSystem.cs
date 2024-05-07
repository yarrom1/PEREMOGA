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

    
    // � ������ ShowLevelUpUI() ������� skillCards �� skillIndex
    private void ShowLevelUpUI()
    {
        isLevelUpScreenActive = true;
        levelUpUI.SetActive(true);

        // ������� ������������ ��� �������� �������
        foreach (Button skillCard in skillCards)
        {
            skillCard.gameObject.SetActive(false);
        }

        // �������� ��������� ���������� �������� ��� �����������
        int numCardsToShow = 3; 

        // ������� ������ �������� � ��������� ���
        List<int> indices = new List<int>();
        for (int i = 0; i < skillCards.Length; i++)
        {
            indices.Add(i);
        }

        // ������������ ������ ��������
        for (int i = 0; i < indices.Count; i++)
        {
            int temp = indices[i];
            int randomIndex = UnityEngine.Random.Range(i, indices.Count);
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        // ���������� ��������� ��������
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
        // ������� ��� ������� Bullet � ����� � ����������� �� ����
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
        // ������� ������ Weapon � ����� � ����������� ��� �������� �����
        shoot weapon = FindObjectOfType<shoot>();
        if (weapon != null)
        {
            weapon.IncreaseFireRate(amount);
        }

    }
    private void IncreaseSpeed(float amount)
    {
        // ������� ������ PlayerMovement � ����������� ��� �������� ������������
        ����� ����� = FindObjectOfType<�����>();
        if (����� != null)
        {
            �����.IncreaseSpeed(amount);
        }
    }
    private void IncreaseHP(float amount)
    {
        // ������� ������ PlayerMovement � ����������� ��� �������� ������������
        Enemy ����� = FindObjectOfType<Enemy>();
        if (����� != null)
        {
            �����.IncreaseHP(amount);
        }
    }
}