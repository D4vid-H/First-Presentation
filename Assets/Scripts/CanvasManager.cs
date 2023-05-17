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
    [SerializeField] private Slider m_healtPlayerSlaider;
    [SerializeField] private PlayerController m_playerController;

    // Update is called once per frame
    void Update()
    {
        WriteScoreCanva(); 
        WriteBullets();
        HealtPercent();
        m_healtPlayerSlaider.value = m_playerController.CurrentHealtPlayer();
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
}
