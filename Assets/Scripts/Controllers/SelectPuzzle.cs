using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPuzzle : MonoBehaviour {

    public GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;
    public Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;

    private string selectedPuzzle;

    public void SelectedPuzzle()
    {
        selectedPuzzle = EventSystem.current.currentSelectedGameObject.name; //Gives selected object name
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
