using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectLevel : MonoBehaviour {

    public GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;
    public Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;

    private string selectedPuzzle;

    public void BackToPuzzleSelectMenu()
    {
        selectedPuzzle = EventSystem.current.currentSelectedGameObject.name; //Gives selected object name
        StartCoroutine(ShowPuzzleSelectMenu());
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

}
