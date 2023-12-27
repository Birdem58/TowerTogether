using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeAyar : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    public AudioSource auMaxwell;
    public AudioSource auChese;
    private float chese = 1;
    private float sValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = 1;
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicLevel();
        }
        auMaxwell.volume = 1;
        auChese.volume = 0;

    }

    public void SetMusicLevel()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("musicLevel", Mathf.Log10(volume) * 10);
        PlayerPrefs.SetFloat("musicVol", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicLevel();
    }
    public void MaxWellCal()
    {
        auMaxwell.volume = 1;
        auChese.volume = 0;
        

    }
    public void CheseCal()
    {
        auMaxwell.volume = 0;
        auChese.volume = 1;

    }
}
