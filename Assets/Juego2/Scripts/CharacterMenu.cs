using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Juego2.Scripts
{
    public class CharacterMenu : MonoBehaviour
    {
        public Button playerFrog;
        public Button playerPink;
        public Button playerVirtual;

        void Start()
        {
            playerFrog.onClick.AddListener(ChooseFrog);
            playerPink.onClick.AddListener(ChoosePink);
            playerVirtual.onClick.AddListener(ChooseVirtual);
        }

        private void SavePlayerAs(string character)
        {
            PlayerPrefs.SetString("character", character);
        }

        void ChooseFrog()
        {
            SavePlayerAs("frog");
            LoadLevel();
        }

        void ChoosePink()
        {
            SavePlayerAs("pink");
            LoadLevel();
        }

        void ChooseVirtual()
        {
            SavePlayerAs("virtual");
            LoadLevel();
        }

        void LoadLevel()
        {
            SceneManager.LoadScene("Nivel1");
        }
    }
}