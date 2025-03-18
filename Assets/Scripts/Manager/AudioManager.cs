using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource sfxAudio, initialMusicAudio;
    public AudioClip initialMusic;
    [SerializeField] AudioMixer master;

    public bool isMute;
    public string musicSavedValue = "musicValue";
    public string sfxSavedValue = "sfxValue";

    private void Awake()
    {
        // Comprobamos si ya existe una instancia de AudioManager en la escena.
        if (Instance == null)
        {
            // Si no existe, establecemos la instancia actual.
            Instance = this;

            // Esto asegura que el AudioManager no se destruya al cambiar de escena.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruimos este objeto para que no haya duplicados.
            Destroy(this.gameObject);
        }
    }

    void Start()
    {

        sfxAudio = transform.Find("SfxAudio").GetComponent<AudioSource>();
        initialMusicAudio = transform.Find("InitialMusic").GetComponent<AudioSource>();

        AssignAudioMixerGroup();

        InitialPlayMusic(initialMusic);
        StopMusic();
    }

    private void AssignAudioMixerGroup()
    {
        AudioMixerGroup[] groups = master.FindMatchingGroups("SfxAudio");

        if (groups.Length > 0)
        {
            sfxAudio.outputAudioMixerGroup = groups[0];
        }

        groups = master.FindMatchingGroups("InitialMusic");
        if (groups.Length > 0)
        {
            initialMusicAudio.outputAudioMixerGroup = groups[0];
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxAudio.PlayOneShot(clip);
    }

    public void InitialPlayMusic(AudioClip clip)
    {

        initialMusicAudio.Stop();

        // Asignamos el nuevo clip de música.
        initialMusicAudio.clip = clip;

        // Reproducimos la nueva música.
        initialMusicAudio.Play();

        // Aseguramos que la música se repita (loop) para que no se detenga.
        initialMusicAudio.loop = true;
    }

    public void MusicVolumeControl(float volume)
    {
        initialMusicAudio.volume = volume;
    }

    public void SFXVolumeControl(float volume)
    {
        // master.SetFloat("SfxAudio", volume);
        sfxAudio.volume = volume;
    }

    public void InitialMusicVolumeControl(float volume)
    {
        // master.SetFloat("InitialMusic", volume);
        initialMusicAudio.volume = volume;
    }

    public void MuteAll()
    {
        isMute = !isMute;
        if (isMute)
        {
            master.SetFloat("Master", -80f);
        }
        else
        {
            master.SetFloat("Master", 0f);
        }
    }

    public IEnumerator TimeStartAudio()
    {
        yield return new WaitForSeconds(2f);
    }

    public void StopMusic()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MenuInitial")
        {
            sfxAudio.Stop();
        }
    }

    public void StopMusicInitial()
    {
        initialMusicAudio.Stop();
    }
}
