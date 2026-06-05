using UnityEngine;
using System.Collections;

public class CrowdManager : MonoBehaviour
{
    [Header("Scenario Settings")]
    public float minTimeBetweenReactions = 5f;
    public float maxTimeBetweenReactions = 15f;

    [Header("Reaction Probabilities (0-1)")]
    [Range(0, 1)] public float positiveProb = 0.4f;
    [Range(0, 1)] public float neutralProb = 0.3f;
    [Range(0, 1)] public float negativeProb = 0.3f;

    [Header("Audio")]
    public AudioClip applauseClip;
    public AudioClip murmureClip;
    public AudioClip boosClip;
    public AudioClip interruptionClip;

    [Header("Animators")]
    public Animator[] crowdAnimators;

    private AudioSource audioSource;
    public string currentReaction = "Neutre";
    public bool sessionActive = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void StartSession()
    {
        sessionActive = true;
        StartCoroutine(ReactionLoop());
        Debug.Log("Session démarrée — la foule va réagir !");
    }

    public void StopSession()
    {
        sessionActive = false;
        StopAllCoroutines();
        Debug.Log("Session terminée.");
    }

    IEnumerator ReactionLoop()
    {
        while (sessionActive)
        {
            float wait = Random.Range(minTimeBetweenReactions, maxTimeBetweenReactions);
            yield return new WaitForSeconds(wait);

            TriggerRandomReaction();
        }
    }

    void TriggerRandomReaction()
    {
        float rand = Random.value;

        if (rand < positiveProb)
            TriggerReaction("Positive");
        else if (rand < positiveProb + neutralProb)
            TriggerReaction("Neutre");
        else
            TriggerReaction("Negative");
    }

    void TriggerReaction(string reaction)
    {
        currentReaction = reaction;

        switch (reaction)
        {
            case "Positive":
                PlaySound(applauseClip);
                SetAnimators("Applause");
                Debug.Log("Foule : applaudissements");
                break;
            case "Neutre":
                PlaySound(murmureClip);
                SetAnimators("Murmure");
                Debug.Log("Foule : murmures");
                break;
            case "Negative":
                PlaySound(boosClip);
                SetAnimators("Boos");
                Debug.Log("Foule : boos !");
                break;
        }
    }

    void SetAnimators(string trigger)
    {
        foreach (Animator anim in crowdAnimators)
        {
            if (anim != null)
                anim.SetTrigger(trigger);
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}