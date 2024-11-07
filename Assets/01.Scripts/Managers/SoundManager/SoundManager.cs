namespace USF.Manager.SoundManager
{
    using System;
    using UnityEngine;
    using USF.Manager.SoundClass;

    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance = null;

        public Sound[] musicSounds, sfxSounds;
        public AudioSource musicSource, sfxSource;

        //�̱���
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #region ���� ����
        public void UpdateMusicVolume(float value)
        {
            musicSource.volume = value;
        }

        public void UpdateSFXVolume(float value)
        {
            sfxSource.volume = value;
        }
        #endregion

        /// <summary>
        /// ������ �����Ű�� �Լ�
        /// </summary>
        /// <param name="name">������ �̸�</param>
        public void PlayMusic(string name)
        {
            Sound s = Array.Find(musicSounds, x => x.name == name);

            if (s == null)
            {
                Debug.Log("Music Not Found");
            }
            else
            {
                musicSource.clip = s.clip;
                musicSource.Play();
            }
        }

        /// <summary>
        /// ������ ���ߴ� �Լ�
        /// </summary>
        public void StopMusic()
        {
            musicSource.Stop();
        }

        /// <summary>
        /// ȿ������ �����Ű�� �Լ�
        /// </summary>
        /// <param name="name">ȿ������ �̸�</param>
        public void PlaySFX(string name)
        {
            Sound s = Array.Find(sfxSounds, x => x.name == name);

            if (s == null)
            {
                Debug.Log("Sount Not Found");
            }
            else
            {
                sfxSource.PlayOneShot(s.clip);
            }
        }
    }
}



