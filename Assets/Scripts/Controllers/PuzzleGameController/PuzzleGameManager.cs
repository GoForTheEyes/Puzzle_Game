using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour {

    private List<Button> puzzleButtons = new List<Button>();

    private List<Animator> puzzleButtonsAnimators = new List<Animator>();

    private List<Sprite> gamePuzzleSprites = new List<Sprite>();

    public GameFinished gameFinished;

    public PuzzleGameSaver puzzleGameSaver;

    private int level;
    private string selectedPuzzle;
    private Sprite puzzleBackgroundImage;

    private bool firstGuess, secondGuess;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzleName, secondGuessPuzzleName;

    private int countrTryGuess;
    private int countCorrectGuess; 
    private int gameGuess;  //number of guesses to end game


    public void PickAPuzzle()
    {
        if (!firstGuess)  //FIRST CLICK
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzleName = gamePuzzleSprites[firstGuessIndex].name;
            StartCoroutine(TurnPuzzleButtonUp(puzzleButtonsAnimators[firstGuessIndex],puzzleButtons[firstGuessIndex],
                            gamePuzzleSprites[firstGuessIndex]));

        } else if (!secondGuess) //SECOND CLICK
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzleName = gamePuzzleSprites[secondGuessIndex].name;
            StartCoroutine(TurnPuzzleButtonUp(puzzleButtonsAnimators[secondGuessIndex], puzzleButtons[secondGuessIndex],
                            gamePuzzleSprites[secondGuessIndex]));
            countrTryGuess++;
            StartCoroutine(CheckIfThePuzzleMatch(puzzleBackgroundImage));


        }

    }

    IEnumerator CheckIfThePuzzleMatch(Sprite puzzleBackgroundImage)
    {
        yield return new WaitForSeconds(1.7f);
        if(firstGuessPuzzleName==secondGuessPuzzleName)
        {
            puzzleButtonsAnimators[firstGuessIndex].Play("FadeOut");
            puzzleButtonsAnimators[secondGuessIndex].Play("FadeOut");
            countCorrectGuess++;
            CheckIfTheGameIsFinished();

        } else
        {
            StartCoroutine(TurnPuzzleButtonBack(puzzleButtonsAnimators[firstGuessIndex], puzzleButtons[firstGuessIndex],
                puzzleBackgroundImage));
            StartCoroutine(TurnPuzzleButtonBack(puzzleButtonsAnimators[secondGuessIndex], puzzleButtons[secondGuessIndex],
                                        puzzleBackgroundImage));
        }
        yield return new WaitForSeconds(.7f);
        firstGuess = secondGuess = false;
    }

    private void CheckIfTheGameIsFinished()
    {
        if (countCorrectGuess == gameGuess)
        {
            CheckHowManyGuesses();
        }
        
    }

    void CheckHowManyGuesses()
    {
        int howManyGuesses = 0;
        switch (level)
        {
            case 0:
                howManyGuesses = 5;
                break;
            case 1:
                howManyGuesses = 10;
                break;
            case 2:
                howManyGuesses = 15;
                break;
            case 3:
                howManyGuesses = 20;
                break;
            case 4:
                howManyGuesses = 25;
                break;

        }

        if (countrTryGuess< howManyGuesses)
        {
            gameFinished.ShowGameFinishedPanel(3);
            puzzleGameSaver.Save(level, selectedPuzzle, 3);
        }
        else if (countrTryGuess < (howManyGuesses+5))
        {
            gameFinished.ShowGameFinishedPanel(2);
            puzzleGameSaver.Save(level, selectedPuzzle, 2);
        }
        else
        {
            gameFinished.ShowGameFinishedPanel(1);
            puzzleGameSaver.Save(level, selectedPuzzle, 1);
        }
    }

    public List<Animator> ResetGameplay()
    {
        firstGuess = secondGuess = false;
        countrTryGuess = 0;
        countCorrectGuess = 0;
        gameFinished.HideGameFinishedPanel();
        return puzzleButtonsAnimators;
    }


    IEnumerator TurnPuzzleButtonUp (Animator anim, Button btn, Sprite puzzleImage)
    {
        anim.Play("TurnUp");
        yield return new WaitForSeconds(.4f);
        btn.image.sprite = puzzleImage;

    }

    IEnumerator TurnPuzzleButtonBack(Animator anim, Button btn, Sprite puzzleImage)
    {
        anim.Play("TurnBack");
        yield return new WaitForSeconds(.4f);
        btn.image.sprite = puzzleImage;

    }


    void AddListeners()
    {
        foreach(Button btn in puzzleButtons)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }


    public void SetUpButtonsAndAnimators(List<Button> buttons, List<Animator> animators)
    {
        this.puzzleButtons = buttons;
        this.puzzleButtonsAnimators = animators;
        gameGuess = puzzleButtons.Count / 2;
        puzzleBackgroundImage = puzzleButtons[0].image.sprite;
        AddListeners();
    }

    public void SetGamePuzzleSprites(List<Sprite> gamePuzzleSprites)
    {
        this.gamePuzzleSprites = gamePuzzleSprites;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public void SetSelectedPuzzle(string selectedPuzzle)
    {
        this.selectedPuzzle = selectedPuzzle;
    }

}
