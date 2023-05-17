using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private PlayerManager m_playerManager;
    [SerializeField] private LevelSceneManager m_sceneManager;

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScoreplayer(int p_scorePlayer)
    {
        m_scoreManager.AddScore(p_scorePlayer);
    }

    public int GetScore()
    {   
        return m_scoreManager.GetScore();
    }

    public void AddPlayerData(PlayerData p_platerData)
    {
        m_playerManager.AddPlayerInfo(p_platerData);
    }

    public PlayerData GetPlayerInfo()
    {
        return m_playerManager.GetPlayerInfo();
    }

    public void TrySceneManager(string p_sceneToLoad)
    {
        m_sceneManager.SceneLoader(p_sceneToLoad);
    }    
}
