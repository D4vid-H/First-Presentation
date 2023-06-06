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
    [SerializeField] private EnemyGuards m_enemyGuards;
    [SerializeField] private EnemyGunOne m_enemyGunOne;
    [SerializeField] private EnemyGunTwo m_enemyGunTwo;
    [SerializeField] private EnemyGunThree m_enemyGunThree;
    [SerializeField] private EnemyGunController m_enemyGunController;

    private void Awake()
    {
        m_textNameEnemy.enabled = false;
        m_healtEnemySlaider.gameObject.SetActive(false);
        m_enemyGuards.OnTargetRangeGuards += OnScreenHealtEnemy;
        m_enemyGunController.OnTargetRange += OnScreenHealtEnemy;
        m_enemyGunController.DeadEnemy += OffScreenHealtEnemy;
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
        if (m_enemyGuards.CurrentHealt() != 100)
        {
            Debug.Log("Resto vida al enemyGuard");
            m_healtEnemySlaider.value = m_enemyGuards.CurrentHealt();
            Debug.Log("Valor" + m_healtEnemySlaider.value);
        }
        if (m_enemyGunOne.CurrentHealt() != 100)
        {
            Debug.Log("Resto vida al enemyGun1");
            Debug.Log("viene del enemy "+m_enemyGunOne.CurrentHealt());
            m_healtEnemySlaider.value = m_enemyGunOne.CurrentHealt();
            Debug.Log("Valor" + m_healtEnemySlaider.value);
        }
        if (m_enemyGunTwo.CurrentHealt() != 100)
        {
            Debug.Log("Resto vida al enemyGun2");
            Debug.Log("viene del enemy " + m_enemyGunTwo.CurrentHealt());
            m_healtEnemySlaider.value = m_enemyGunTwo.CurrentHealt();
            Debug.Log("Valor" + m_healtEnemySlaider.value);
        }
        if (m_enemyGunThree.CurrentHealt() != 100)
        {
            Debug.Log("Resto vida al enemyGu3");
            Debug.Log("viene del enemy " + m_enemyGunThree.CurrentHealt());
            m_healtEnemySlaider.value = m_enemyGunThree.CurrentHealt();
            Debug.Log("Valor" + m_healtEnemySlaider.value);
        }        
    }

    private void OnScreenHealtEnemy()
    {
        Debug.Log("Entre al OnScreen");
        m_textNameEnemy.enabled = true;
        m_healtEnemySlaider.gameObject.SetActive(true);
    }
    private void OffScreenHealtEnemy()
    {
        Debug.Log("Entre al OffScreen");
        m_textNameEnemy.enabled = false;
        m_healtEnemySlaider.gameObject.SetActive(false);
    }

}
