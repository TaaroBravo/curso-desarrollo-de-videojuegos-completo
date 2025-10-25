using System;
using System.Collections.Generic;
using UnityEngine;

namespace Juego2.Scripts
{
    public class PlayerPrefsExample : MonoBehaviour
    {
        void Start()
        {
            var json = PlayerPrefs.GetString("PlayerInfo");
            PlayerInfo playerInfo = JsonUtility.FromJson<PlayerInfo>(json);
        }

        private void SaveJson()
        {
            var playerInfo = new PlayerInfo
            {
                playerName = "Jorge",
                characterChosen = "frog",
                points = 100,
                life = 2.5f,
                weapons = new List<Weapon>
                {
                    new Weapon
                    {
                        name = "Pistol",
                        maxBullets = 15
                    }
                },
            };

            string json = JsonUtility.ToJson(playerInfo);
            PlayerPrefs.SetString("PlayerInfo", json);
        }
    }

    [Serializable]
    public class PlayerInfo
    {
        public string playerName;
        public string characterChosen;
        public int points;
        public float life;
        public List<Weapon> weapons;
    }

    [Serializable]
    public class Weapon
    {
        public string name;
        public int maxBullets;
    }
}