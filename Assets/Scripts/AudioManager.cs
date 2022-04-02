using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager current;

    [Header("EffectSound")]
    public AudioClip jumpClip;
    public AudioClip collectClip;
    public AudioClip clickClip;
    public AudioClip deadClip;

    AudioSource effectSource;

    [Header("BGM")]
    public AudioClip[] bgmClips;
    AudioSource bgmSource;

    public static int bgmIndex;

    private void Awake()
    {
        if (current != null)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
        DontDestroyOnLoad(gameObject);

        effectSource = gameObject.AddComponent<AudioSource>();
        bgmSource = gameObject.AddComponent<AudioSource>();

        bgmSource.volume = 0.4f;
        PlayStartMenuBgm();
    }

    public static void PlayJumpAudio()
    {
        current.effectSource.clip = current.jumpClip;
        current.effectSource.Play();        
    }

    public static void PlayDeathAudio()
    {
        current.effectSource.clip = current.deadClip;
        current.effectSource.Play();
    }

    public static void PlayCollectAudio()
    {
        current.effectSource.clip = current.collectClip;
        current.effectSource.Play();
    }

    public static void PlayClickAudio()
    {
        current.effectSource.clip = current.clickClip;
        current.effectSource.Play();
    }

    public static void PlayStartMenuBgm()
    {
        current.bgmSource.clip = current.bgmClips[0];
        current.bgmSource.loop = true;
        current.bgmSource.Play();
    }


    public static void PlayChooseMenuBgm()
    {
        current.bgmSource.clip = current.bgmClips[1];
        current.bgmSource.loop = true;
        current.bgmSource.Play();
    }

    public static void PlayGameBgm()
    {
        bgmIndex = Random.Range(2, 4);
        current.bgmSource.clip = current.bgmClips[bgmIndex];
        current.bgmSource.loop = true;
        current.bgmSource.Play();
    }
}
