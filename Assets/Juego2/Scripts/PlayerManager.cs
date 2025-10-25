using UnityEngine;

namespace Juego2.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject frogPlayer;
        public GameObject virtualPlayer;
        public GameObject pinkPlayer;
    
        void Start()
        {
            string character = PlayerPrefs.GetString("character", "frog");
            SpawnCharacter(character);
        }

        void SpawnCharacter(string character)
        {
            if (character == "frog")
                Instantiate(frogPlayer);
            if (character == "virtual")
                Instantiate(virtualPlayer);
            if (character == "pink")
                Instantiate(pinkPlayer);
        }
    }
}
