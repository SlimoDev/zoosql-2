using UnityEngine;

namespace Data
{
    public class PlayerPrefsStoreAdapter : IConfigDataStore
    {
        public void SaveConfigData(ConfigData configData)
        {
            PlayerPrefs.SetInt("currentLevel", configData.currentLevel);
            PlayerPrefs.SetString("currentTopic", configData.currentTopic);
            PlayerPrefs.SetString("currentGameType", configData.currentGameType);
            PlayerPrefs.SetInt("currentDifficulty", configData.currentDifficulty);
            PlayerPrefs.SetInt("isMusicOn", configData.isMusicOn ? 1 : 0);
            PlayerPrefs.SetInt("isSoundOn", configData.isSoundOn ? 1 : 0);
        }

        public ConfigData LoadConfigData()
        {
            ConfigData configData = new()
            {
                currentLevel = PlayerPrefs.GetInt("currentLevel", 0),
                currentGameType = PlayerPrefs.GetString("currentGameType", ""),
                currentTopic = PlayerPrefs.GetString("currentTopic", ""),
                currentDifficulty = PlayerPrefs.GetInt("currentDifficulty", 0),
                isMusicOn = PlayerPrefs.GetInt("isMusicOn", 1) == 1,
                isSoundOn = PlayerPrefs.GetInt("isSoundOn", 1) == 1
            };
            return configData;
        }
    }
}