using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] private EventManager m_events = null;
    [Space]
    [SerializeField] private AudioSource m_bkgMusic = null;
    [SerializeField] private AudioSource m_failMusic = null;
    [Space]
    [SerializeField] private AudioSource m_soundSource = null;


    private void OnEnable()
    {
        m_events.GameOver += OnGameOver;

        m_bkgMusic.Play();
    }

    private void OnDisable()
    {
        m_events.GameOver -= OnGameOver;
        
        m_bkgMusic.Stop();
        m_failMusic.Stop();
    }


    private void OnGameOver()
    {
        m_bkgMusic.Stop();
        m_failMusic.Play();
    }


    public void Play(AudioClip clip)
    {
        m_soundSource.PlayOneShot(clip);
    }
}