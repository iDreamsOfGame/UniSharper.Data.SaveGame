using UniSharper.Data.SaveGame.Providers;
using UnityEngine;
using UnityEngine.UI;

namespace UniSharper.Data.SaveGame.Samples
{
    public enum CipherMode
    {
        Ecb,
        
        Cbc
    }
    
    public class SaveGameSample : MonoBehaviour
    {
        private const string Key = "SAnzX2EoRV9Haaqc";
        
        [SerializeField]
        private CipherMode cipherMode = CipherMode.Cbc;

        [SerializeField]
        private InputField inputField;

        [SerializeField]
        private Button loadGameButton;

        private ISaveGameManager manager;
        
        private string GameDataName => cipherMode == CipherMode.Ecb ? "SaveGameExample" : "SaveGameExampleCbc";

        public void OnLoadGameButtonClicked()
        {
            LoadGame();
        }

        public void OnSaveGameButtonClicked()
        {
            if (!string.IsNullOrEmpty(inputField.text))
            {
                var success = manager.SaveGame(GameDataName, inputField.text, true, true);
                inputField.text = string.Empty;
                loadGameButton.interactable = success;
            }
        }

        private void Awake()
        {
            ICryptoProvider cryptoProvider = cipherMode == CipherMode.Cbc ? new AesCbcCryptoProvider() : new AesEcbCryptoProvider();
            manager = new SaveGameManager();
            manager.Initialize(null, cryptoProvider);
            loadGameButton.interactable = manager.ExistsSaveData(GameDataName);
        }

        private void LoadGame()
        {
            var content = manager.LoadGame(GameDataName);
            if (string.IsNullOrEmpty(content))
                return;

            inputField.text = content;
        }
    }
}