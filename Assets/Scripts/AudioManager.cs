using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Type")]
    public AudioClip bgMusic;
    public AudioClip death;
    public AudioClip win;
    public AudioClip walk;
    public AudioClip hit;
    public AudioClip damage;
    public AudioClip button;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);    
        } else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        musicSource.clip = bgMusic;
        musicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }


}
