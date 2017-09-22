using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class PuzzleGameSaver : MonoBehaviour {

    private GameData gameData;

    public bool[] candyPuzzleLevels;
    public bool[] transportPuzzleLevels;
    public bool[] fruitPuzzleLevels;

    public int[] candyPuzzleLevelStars;
    public int[] transportPuzzleLevelStars;
    public int[] fruitPuzzleLevelStars;

    private bool isTheGameStartedForTheFirstTime;

    public float musicVolume;

    private void Awake()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        LoadGameData();
        if (gameData != null)
        {
            isTheGameStartedForTheFirstTime = gameData.GetIsTheGameStartedForTheFirstTime();
        } else
        {
            isTheGameStartedForTheFirstTime = true;
        }

        if (isTheGameStartedForTheFirstTime)
        {
            isTheGameStartedForTheFirstTime = false;
            musicVolume = 0;
            candyPuzzleLevels = new bool[5];
            fruitPuzzleLevels = new bool[5];
            transportPuzzleLevels = new bool[5];

            candyPuzzleLevels[0] = transportPuzzleLevels[0] = fruitPuzzleLevels[0] = true;
            candyPuzzleLevels[1] = transportPuzzleLevels[1] = fruitPuzzleLevels[1] = false;
            candyPuzzleLevels[2] = transportPuzzleLevels[2] = fruitPuzzleLevels[2] = false;
            candyPuzzleLevels[3] = transportPuzzleLevels[3] = fruitPuzzleLevels[3] = false;
            candyPuzzleLevels[4] = transportPuzzleLevels[4] = fruitPuzzleLevels[4] = false;

            candyPuzzleLevelStars = new int[5];
            transportPuzzleLevelStars = new int[5];
            fruitPuzzleLevelStars = new int[5];

            for (int i = 0; i < candyPuzzleLevelStars.Length; i++)
            {
                candyPuzzleLevelStars[i] = transportPuzzleLevelStars[i] = fruitPuzzleLevelStars[i] = 0;
            }

            gameData = new GameData();

            gameData.SetCandyPuzzleLevels(candyPuzzleLevels);
            gameData.SetTransportPuzzleLevels(transportPuzzleLevels);
            gameData.SetFruitPuzzleLevels(fruitPuzzleLevels);

            gameData.SetCandyPuzzleLevelStars(candyPuzzleLevelStars);
            gameData.SetTransportPuzzleLevelStars(transportPuzzleLevelStars);
            gameData.SetFruitPuzzleLevelStars(fruitPuzzleLevelStars);

            gameData.SetIsTheGameStartedForTheFirstTime(isTheGameStartedForTheFirstTime);
            gameData.SetMusicVolume(musicVolume);

            SaveGameData();
            LoadGameData();

        }

    }

    public void SaveGameData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + "/GameData.sav");

            if (gameData != null)
            {
                gameData.SetCandyPuzzleLevels(candyPuzzleLevels);
                gameData.SetTransportPuzzleLevels(transportPuzzleLevels);
                gameData.SetFruitPuzzleLevels(fruitPuzzleLevels);

                gameData.SetCandyPuzzleLevelStars(candyPuzzleLevelStars);
                gameData.SetTransportPuzzleLevelStars(transportPuzzleLevelStars);
                gameData.SetFruitPuzzleLevelStars(fruitPuzzleLevelStars);

                gameData.SetIsTheGameStartedForTheFirstTime(isTheGameStartedForTheFirstTime);
                gameData.SetMusicVolume(musicVolume);

                bf.Serialize(file, gameData);
            }
          
        }
        catch (Exception error)
        {
            Debug.Log("Save Error: " + error);
        } 
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

    void LoadGameData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "/GameData.sav", FileMode.Open);
            gameData = (GameData)bf.Deserialize(file); //Turn the data into GameData
            if (gameData != null)
            {
                candyPuzzleLevels = gameData.GetCandyPuzzleLevels();
                transportPuzzleLevels = gameData.GetTransportPuzzleLevels();
                fruitPuzzleLevels = gameData.GetFruitPuzzleLevels();

                candyPuzzleLevelStars = gameData.GetCandyPuzzleLevelStars();
                transportPuzzleLevelStars = gameData.GetTransportPuzzleLevelStars();
                fruitPuzzleLevelStars = gameData.GetFruitPuzzleLevelStars();

                isTheGameStartedForTheFirstTime = gameData.GetIsTheGameStartedForTheFirstTime();
                musicVolume = gameData.GetMusicVolume();
            }
        }
        catch (Exception error)
        {
            Debug.Log("Load Error: " + error);
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }


    public void Save(int level, string selectedPuzzle, int stars)
    {
        int unlockNextLevel = -1;

        switch (selectedPuzzle) {
            case "Candy Puzzle":
                unlockNextLevel = level + 1;
                candyPuzzleLevelStars[level] = stars;
                if(unlockNextLevel < candyPuzzleLevels.Length)
                {
                    candyPuzzleLevels[unlockNextLevel] = true;
                }
                break;
            case "Transport Puzzle":
                unlockNextLevel = level + 1;
                transportPuzzleLevelStars[level] = stars;
                if (unlockNextLevel < transportPuzzleLevels.Length)
                {
                    transportPuzzleLevels[unlockNextLevel] = true;
                }
                break;
            case "Fruit Puzzle":
                unlockNextLevel = level + 1;
                fruitPuzzleLevelStars[level] = stars;
                if (unlockNextLevel < fruitPuzzleLevels.Length)
                {
                    fruitPuzzleLevels[unlockNextLevel] = true;
                }
                break;
        }

    }

}
