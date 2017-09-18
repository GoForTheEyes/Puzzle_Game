using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour {

    public GameObject settingsPanel;
    public Animator settingsPanelAnim;

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
        settingsPanelAnim.Play("SlideIn");
    }

    public void CloseSettingsPanel()
    {
        StartCoroutine(CloseSettings());
    }

    IEnumerator CloseSettings()
    {
        settingsPanelAnim.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        settingsPanel.SetActive(false);
    }


}
