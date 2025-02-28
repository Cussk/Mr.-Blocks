using UnityEngine;

namespace Sound
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] AudioSource backgroundAudioSource;
        [SerializeField] AudioSource soundFXAudioSource;
        [SerializeField] AudioClip levelCompleteAudio;
        [SerializeField] AudioClip gameOverAudio;
        [SerializeField] AudioClip buttonClickAudio;
        
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            PlayBackgroundMusic();
        }
        
        public void PlayLevelCompleteAudio() => PlayAudioClip(levelCompleteAudio);
        public void PlayGameOverAudio() => PlayAudioClip(gameOverAudio);
        public void PlayButtonClickAudio() => PlayAudioClip(buttonClickAudio);
        
        public void DestroySoundManager() => Destroy(gameObject);

        void PlayBackgroundMusic()
        {
            bool isSourceAndClipExists = backgroundAudioSource != null && backgroundAudioSource.clip != null;
            bool isMusicPlaying = backgroundAudioSource.isPlaying;
            
            if (isSourceAndClipExists && !isMusicPlaying)
                backgroundAudioSource.Play();
        }

        void PlayAudioClip(AudioClip audioClip)
        {
            bool isSourceAndClipExists = soundFXAudioSource != null && audioClip != null;
            
            if (isSourceAndClipExists)
                soundFXAudioSource.PlayOneShot(audioClip);
        }
    }
}
