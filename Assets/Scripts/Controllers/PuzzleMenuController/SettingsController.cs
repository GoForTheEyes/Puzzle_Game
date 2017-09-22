using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    public MusicController musicController;
    public GameObject settingsPanel;
    public Animator settingsPanelAnim;

    public Slider musicSlider;




    public void OpenSettingsPanel()
    {
        musicSlider.value = musicController.GetMusicVolume();
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

    public void GetVolume(float volume)
    {
        musicController.SetMusicVolume(volume);
    }

}
