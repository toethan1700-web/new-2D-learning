using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicSource;

    public GameObject sfxSourcePrefab;
    public AudioClip musicClip;
    public float musicVolume = 0.5f;
    public float sfxVolume = 0.5f;

    private void Awake()
    {
       if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        playmusic(musicClip);
    }
    public void PlaySFX(AudioClip SFXclip)
    {
        var sfxSource = Instantiate(sfxSourcePrefab);
        var sourceComponent = sfxSource.GetComponent<AudioSource>();
        sourceComponent.PlayOneShot(SFXclip);
        sourceComponent.volume = sfxVolume;
        Destroy(sfxSource, SFXclip.length);
    }
    public void playmusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }
    public void setMusicVolume(float volume)
    {
        musicVolume = volume;
    }
    public void setSFXvolume(float volume)
    {
        sfxVolume = volume;
    }
}
