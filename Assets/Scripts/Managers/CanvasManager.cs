using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private TMP_Text m_textScore;
    [SerializeField] private TMP_Text m_textBullets;
    [SerializeField] private TMP_Text m_textHealtPercent;
    [SerializeField] private TMP_Text m_textNameEnemy;
    [SerializeField] private Slider m_healtPlayerSlaider;
    [SerializeField] private Slider m_healtEnemySlaider;
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private Enemy m_enemy;
    [SerializeField] private MechaController m_Boss;
    [SerializeField] private EnemyGuards m_enemyGuards;
    [SerializeField] private EnemyGunOne m_enemyGunOne;
    [SerializeField] private EnemyGunTwo m_enemyGunTwo;
    [SerializeField] private EnemyGunThree m_enemyGunThree;
    [SerializeField] private EnemyGunController m_enemyGunController;

    private void Awake()
    {
        m_textNameEnemy.enabled = false;
        m_healtEnemySlaider.gameObject.SetActive(false);
        m_enemy.OnTargetRangeGuards += OnScreenHealtEnemy;
        m_enemy.DiedGuards += OffScreenHealtEnemy;
        m_enemyGunController.OnTargetRange += OnScreenHealtEnemy;
        m_enemyGunController.DeadEnemy += OffScreenHealtEnemy;
        m_Boss.Activate.AddListener(OnScreenHealtEnemy);
    }
    // Update is called once per frame
    void Update()
    {
        WriteScoreCanva(); 
        WriteBullets();
        HealtPercent();
        CurrentHealtPlayer();
        CurrentHealtEnemy();
    }

    private void WriteScoreCanva()
    {
        string l_ScoreRender = Convert.ToString(GameManager.Instance.GetScore());
        m_textScore.text = l_ScoreRender;
    }

    private void WriteBullets()
    {
        string l_countBulltes = Convert.ToString(m_playerController.GetCurrentAmmunition());
        m_textBullets.text = l_countBulltes;
    }
    
    private void HealtPercent()
    {
        string l_HealtPercent = Convert.ToString(m_playerController.CurrentHealtPlayer() * 100);
        m_textHealtPercent.text = l_HealtPercent+" %";
    }

    private void CurrentHealtPlayer()
    {
        m_healtPlayerSlaider.value = m_playerController.CurrentHealtPlayer();
    }

    private void CurrentHealtEnemy()
    {
        if (m_enemyGuards.CurrentHealt() != 1)
        {
            m_healtEnemySlaider.value = m_enemyGuards.CurrentHealt();
            if (m_textNameEnemy.enabled == true) 
            {
                m_textNameEnemy.text = m_enemyGuards.GetNameEntity();
            }
        }
        if (m_enemyGunOne.CurrentHealt() != 1)
        {
            m_healtEnemySlaider.value = m_enemyGunOne.CurrentHealt();
            if (m_textNameEnemy.enabled == true)
            {
                m_textNameEnemy.text = m_enemyGunOne.GetName();
            }
        }
        if (m_enemyGunTwo.CurrentHealt() != 1)
        {
            m_healtEnemySlaider.value = m_enemyGunTwo.CurrentHealt();
            if (m_textNameEnemy.enabled == true)
            {
                m_textNameEnemy.text = m_enemyGunTwo.GetName();
            }
        }
        if (m_enemyGunThree.CurrentHealt() != 1)
        {
            m_healtEnemySlaider.value = m_enemyGunThree.CurrentHealt();
            if (m_textNameEnemy.enabled == true)
            {
                m_textNameEnemy.text = m_enemyGunThree.GetName();
            }
        }
        if (m_Boss.CurrentHealt() != 1)
        {
            m_healtEnemySlaider.value = m_Boss.CurrentHealt();
            if (m_textNameEnemy.enabled == true)
            {
                m_textNameEnemy.text = m_Boss.GetName();
            }
        }
    }
    private void OnScreenHealtEnemy()
    {
        m_textNameEnemy.enabled = true;
        m_healtEnemySlaider.gameObject.SetActive(true);
    }
    private void OffScreenHealtEnemy()
    {
        m_textNameEnemy.enabled = false;
        m_healtEnemySlaider.gameObject.SetActive(false);
    }

}
