using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectLevel : MonoBehaviour {

    public GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;
    public Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;
    public LoadPuzzleGame loadPuzzleGame;
    public PuzzleGameManager puzzleGameManager;
    public LevelLocker levelLocker;

    private bool[] puzzle;
    private string selectedPuzzle;

    public void BackToPuzzleSelectMenu()
    {
        StartCoroutine(ShowPuzzleSelectMenu());
    }

    public void SelectPuzzleLevel()
    {
        //We are going to use our items name as an integer, that is why they are named 0,1,2,3,4 respectively
        int level = int.Parse(EventSystem.current.currentSelectedGameObject.name); //Gives selected object name
        puzzle = levelLocker.GetPuzzleLevels(selectedPuzzle);

        if (puzzle [level])
        {
            puzzleGameManager.SetLevel(level); //Pass level to the game manager
            loadPuzzleGame.LoadPuzzle(level, selectedPuzzle);
        }
    }


    IEnumerator ShowPuzzleSelectMenu()
    {
        //Changes from the level of selected puzzle view to select category of puzzle menu
        selectPuzzleMenuPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SlideIn");
        puzzleLevelSelectAnim.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        puzzleLevelSelectPanel.SetActive(false);

    }

    public void SetSelectedPuzzle(string puzzle)
    {
        //Buttons will have this option with their name as an input value to this method
        //that input value will populate the script (this.selectedPuzzle) value
        this.selectedPuzzle = puzzle;
    }


}
