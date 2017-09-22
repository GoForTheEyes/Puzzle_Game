using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinished : MonoBehaviour {

    public GameObject gameFinishedPanel;
    public Animator gameFinishedAnim, star1Anim, star2Anim, star3Anim, textAnim;

    public void ShowGameFinishedPanel(int stars)
    {
        StartCoroutine(ShowPanel(stars));
    }

    public void HideGameFinishedPanel()
    {
        if(gameFinishedPanel.activeInHierarchy)
        {
            StartCoroutine(HidePanel());
        }
    }

    IEnumerator ShowPanel(int stars)
    {
        gameFinishedPanel.SetActive(true);
        gameFinishedAnim.Play("FadeIn");
        yield return new WaitForSeconds(1.7f);
        switch (stars)
        {
        case 1:
            star1Anim.Play("FadeIn");
            break;

        case 2:
            star1Anim.Play("FadeIn");
            yield return new WaitForSeconds(.25f);
            star2Anim.Play("FadeIn");
            break;

        case 3:
            star1Anim.Play("FadeIn");
            yield return new WaitForSeconds(.25f);
            star2Anim.Play("FadeIn");
            yield return new WaitForSeconds(.25f);
            star3Anim.Play("FadeIn");
            break;
        }
        yield return new WaitForSeconds(.1f);
        textAnim.Play("TextFadeIn");
    }

    IEnumerator HidePanel()
    {
        gameFinishedAnim.Play("FadeOut");
        if (star1Anim.GetCurrentAnimatorStateInfo(0).IsName("FadeIn")) star1Anim.Play("FadeOut");
        if (star2Anim.GetCurrentAnimatorStateInfo(0).IsName("FadeIn")) star2Anim.Play("FadeOut");
        if (star3Anim.GetCurrentAnimatorStateInfo(0).IsName("FadeIn")) star3Anim.Play("FadeOut");

        textAnim.Play("TextFadeIn");
        yield return new WaitForSeconds(1.5f);
        gameFinishedPanel.SetActive(false);
    }




}
