using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPuzzle : MonoBehaviour {

    public LevelLocker levelLocker;
    public GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;
    public Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;
    public SelectLevel selectLevel;
    public PuzzleGameManager puzzleGameManager;
    public StarsLocker starsLocker;

    private string selectedPuzzle;

    public void SelectedPuzzle()
    {
        starsLocker.DeactivateStars();
        selectedPuzzle = EventSystem.current.currentSelectedGameObject.name; //Gives selected object name
        puzzleGameManager.SetSelectedPuzzle(selectedPuzzle);  //pass puzzle type to the game manager
        levelLocker.CheckWichLevelsAreUnlocked(selectedPuzzle);
        selectLevel.SetSelectedPuzzle(selectedPuzzle);
        StartCoroutine(ShowPuzzleLevelSelectMenu());
    }

    IEnumerator ShowPuzzleLevelSelectMenu()
    {
        //Changes from the select category of puzzle to the level of selected puzzle view
        puzzleLevelSelectPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SlideOut");
        puzzleLevelSelectAnim.Play("SlideIn");
        yield return new WaitForSeconds(1f);
        selectPuzzleMenuPanel.SetActive(false);
    }

}
