using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance;

    [SerializeField] private GameObject fadeCanvas = null;

    private Animator anim = null;
    private AnimationClip animationClip = null;

    private void Awake()
    {
        #region ΩÃ±€≈Ê
        if (instance == null)
        {
            instance = this;
        }
        #endregion

        anim = GetComponentInChildren<Animator>();
    }

    //∆‰¿ÃµÂ ¿Œ
    public void FadeIn(Action function)
    {
        fadeCanvas.gameObject.SetActive(true);
        anim.SetTrigger("FadeIn");
        StartCoroutine(Co_FadeIn(function));
    }

    //∆‰¿ÃµÂ æ∆øÙ
    public void FadeOut(Action function)
    {
        fadeCanvas.gameObject.SetActive(true);
        anim.SetTrigger("FadeOut");
        StartCoroutine(Co_FadeOut(function));
    }

    private IEnumerator Co_FadeOut(Action function)
    {
        yield return new WaitForSeconds(GetClipTime("FadeOut"));
        if (function != null)
        {
            function();
        }
        fadeCanvas.gameObject.SetActive(false);
        StopAllCoroutines();
    }
    private IEnumerator Co_FadeIn(Action function)
    {
        yield return new WaitForSeconds(GetClipTime("FadeIn"));
        if (function != null)
        {
            function();
        }
        StopAllCoroutines();
    }

    private float GetClipTime(string clipName)
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == clipName)
            {
                animationClip = clip;
                return clip.length;
            }
        }

        Debug.LogError("NOT FOUND CLIPS");
        return 0f;
    }
}
