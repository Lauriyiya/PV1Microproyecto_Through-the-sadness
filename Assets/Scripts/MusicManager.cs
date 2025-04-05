using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField]
    private MusicLibrary musicLibrary;

    [SerializeField]
    private AudioSource musicSource;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(string trackName, float fadeOutDuration = 0.5f, float fadeInDuration = 0.5f)
    {
        var clip = musicLibrary.GetClipFromName(trackName);
        if (clip == null) return;

        StartCoroutine(AnimateMusicCrossFade(clip, fadeOutDuration, fadeInDuration));
    }

    IEnumerator AnimateMusicCrossFade(AudioClip nextTrack, float fadeOutDuration = 0.5f, float fadeInDuration = 0.5f)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeOutDuration;
            musicSource.volume = Mathf.Lerp(1f, 0, percent);
            yield return null;
        }

        musicSource.clip = nextTrack;
        musicSource.Play();

        percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeInDuration;
            musicSource.volume = Mathf.Lerp(0, 1f, percent);
            yield return null;
        }
    }
}
