using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private SoundLibrary sfxLibrary;

    [SerializeField]
    private AudioSource sfx2DSource;

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

    public void PlaySound3D(AudioClip clip, Vector3 pos)
    {
        if (clip == null) return;
        if (pos == null) return;

        AudioSource.PlayClipAtPoint(clip, pos);
    }

    public void PlaySound3D(string name, Vector3 pos)
    {
        if (pos == null) return;

        var clip = sfxLibrary.GetClipFromName(name);
        if (clip == null) return;

        PlaySound3D(clip, pos);
    }

    public void PlaySound2D(string soundName)
    {
        var clip = sfxLibrary.GetClipFromName(name);
        if (clip == null) return;

        sfx2DSource.PlayOneShot(clip);
    }
}
