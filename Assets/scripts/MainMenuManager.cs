using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public GameObject optionPanel;

    private void Start()
    {
        var musicVolume = SaveManager.Instance.GetMusicVolume();
        var sfxVolume=SaveManager.Instance.GetSfxVolume();
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OptionOn()
    {
        optionPanel.SetActive(true);
    }
    public void Back()
    {
        SaveManager.Instance.saveMusicVolume(musicSlider.value);
        SaveManager.Instance.saveSfxVolume(sfxSlider.value);
        optionPanel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Update()
    {
        AudioManager.Instance.setMusicVolume(musicSlider.value);
        AudioManager.Instance.setSFXvolume(sfxSlider.value);
    }
}
