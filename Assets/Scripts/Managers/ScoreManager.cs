using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int m_scorePlayer = 0;

    public void AddScore(int p_scoreToAdd)
    {
        m_scorePlayer += p_scoreToAdd;
    }

    public int GetScore()
    {
        return m_scorePlayer;
    } 

}
