using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public int age;
    public string name;
    public string user;
    public int score;

    public override string ToString()
    {
        string l_playerInfo = string.Empty;
        l_playerInfo += "Age: " + age + "," + "Player Name: " + name + "," + "Player User: " + user + "," + "PlayerScore" + score;
        return l_playerInfo;
    }
}
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private string m_namePlayer;
    [SerializeField] private string m_userPlayer;
    [SerializeField] private int m_agePlayer;
    private Dictionary<string, PlayerData> m_playerDirectory = new Dictionary<string, PlayerData>();
    [SerializeField] private PlayerData m_playerInfo;
    public void AddPlayerInfo(PlayerData p_playerInfo)
    {
            m_playerDirectory.Add("Player", p_playerInfo);        
    }
    public PlayerData GetPlayerInfo()
    {
        if (m_playerDirectory.TryGetValue("Player", out PlayerData l_infoPlayer))
        {
            return l_infoPlayer;
        }
        return m_playerInfo;
    }
}
