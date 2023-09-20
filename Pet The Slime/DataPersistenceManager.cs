using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;


    public static DataPersistenceManager instance { get; private set; }
    private FileDataHandler dataHandler;
    private GameData gameData;
    private List<IDataPersistance> dataPersistance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistance = FindAllDataPersistanceOnjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
            NewGame();
        foreach(IDataPersistance data in dataPersistance)
        {
            data.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        foreach (IDataPersistance data in dataPersistance)
        {
            data.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }

    private List<IDataPersistance> FindAllDataPersistanceOnjects()
    {
        IEnumerable<IDataPersistance> dataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistances);
    }
}
