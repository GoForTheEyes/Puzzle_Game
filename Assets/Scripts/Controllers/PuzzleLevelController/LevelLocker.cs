using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLocker : MonoBehaviour {

    public PuzzleGameSaver puzzleGameSaver;
    public GameObject[] levelStarsHolder;
    public GameObject[] levelsPadlocks;
    public StarsLocker starsLocker;

    private bool[] candyPuzzleLevels;
    private bool[] transportPuzzleLevels;
    private bool[] fruitPuzzleLevels;

    public void CheckWichLevelsAreUnlocked(string selectedPuzzle)
    {
        DeactivatePadlocksAndStarHolders();
        GetLevels();

        switch (selectedPuzzle)
        {
            case "Candy Puzzle":
                for (int i = 0; i < candyPuzzleLevels.Length; i++)
                {
                    if (candyPuzzleLevels[i])
                    {
                        levelStarsHolder[i].SetActive(true);
                        starsLocker.ActivateStars(i, selectedPuzzle);
                    } else
                    {
                        levelsPadlocks[i].SetActive(true);
                    }
                }
                break;

            case "Transport Puzzle":
                for (int i = 0; i < transportPuzzleLevels.Length; i++)
                {
                    if (transportPuzzleLevels[i])
                    {
                        levelStarsHolder[i].SetActive(true);
                        starsLocker.ActivateStars(i, selectedPuzzle);
                    }
                    else
                    {
                        levelsPadlocks[i].SetActive(true);
                    }
                }
                break;

            case "Fruit Puzzle":
                for (int i = 0; i < fruitPuzzleLevels.Length; i++)
                {
                    if (fruitPuzzleLevels[i])
                    {
                        levelStarsHolder[i].SetActive(true);
                        starsLocker.ActivateStars(i, selectedPuzzle);
                    }
                    else
                    {
                        levelsPadlocks[i].SetActive(true);
                    }
                }
                break;
        }
    }

    void DeactivatePadlocksAndStarHolders()
    {
        for (int i = 0; i < levelStarsHolder.Length; i++)
        {
            levelStarsHolder[i].SetActive(false);
            levelsPadlocks[i].SetActive(false);
        }
    }

    void GetLevels()
    {
        candyPuzzleLevels = puzzleGameSaver.candyPuzzleLevels;
        transportPuzzleLevels = puzzleGameSaver.transportPuzzleLevels;
        fruitPuzzleLevels = puzzleGameSaver.fruitPuzzleLevels;
    }

#pragma warning disable 0162
    public bool[] GetPuzzleLevels(string selectedPuzzle)
    {
        switch(selectedPuzzle)
        {
            case "Candy Puzzle":
                return candyPuzzleLevels;
                break;

            case "Transport Puzzle":
                return transportPuzzleLevels;
                break;

            case "Fruit Puzzle":
                return fruitPuzzleLevels;
                break;

            default:
                return null;
                break;
        }
    }
#pragma warning restore

}
