using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;


public class DataManager : MonoBehaviour
{
    //set privado get publico
    public static DataManager Instance { private set; get; }
    [field: SerializeField]
    public Dificultad Dificultad { get; set; }
    [field: SerializeField]
    public Tema Tema { get; set; }
    
    private IConfigDataStore _configDataStore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            _configDataStore = new PlayerPrefsStoreAdapter();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void SaveConfigData(ConfigData configData)
    {
        _configDataStore.SaveConfigData(configData);
    }

    public ConfigData LoadConfigData()
    {
        return _configDataStore.LoadConfigData();
    }

}
