using UnityEngine;
using UnityEngine.Rendering;

public class SaveManager : MonoBehaviour
{
    //singleton pattern
    public static SaveManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void saveMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicVolume", volume);//key,value pair
        PlayerPrefs.Save();
    }
    public void saveSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat("sfxVolume", volume);
        PlayerPrefs.Save();
    }
    public float GetMusicVolume()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            return PlayerPrefs.GetFloat("musicVolume");

        }
        else
        {
            return 1;
        }
    }
    public float GetSfxVolume()
    {
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
           return PlayerPrefs.GetFloat("sfxVolume");

        }
        else
        {
            return 1;
        }
        

    }

    
    
       
}
