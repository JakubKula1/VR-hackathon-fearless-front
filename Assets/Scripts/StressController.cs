using UnityEngine;
using System.Collections.Generic;

public class StressController : MonoBehaviour
{
    [Header("BPM Settings")]
    [Range(0, 200)]
    public float currentBPM = 70f;
    public float calmBPM = 70f;
    public float maxBPM = 160f;

    [Header("Session Data")]
    public float averageBPM = 0f;
    public float peakBPM = 0f;
    public float stressScore = 0f;

    private List<float> bpmHistory = new List<float>();
    private List<string> reactionLog = new List<string>();
    private CrowdManager crowdManager;
    private bool isRecording = false;

    void Start()
    {
        crowdManager = FindObjectOfType<CrowdManager>();
    }

    public void StartSession()
    {
        bpmHistory.Clear();
        reactionLog.Clear();
        peakBPM = 0f;
        averageBPM = 0f;
        stressScore = 0f;
        isRecording = true;
        crowdManager?.StartSession();
        Debug.Log("Enregistrement BPM démarré !");
    }

    public void StopSession()
    {
        isRecording = false;
        crowdManager?.StopSession();
        CalculateResults();
        Debug.Log($"Session terminée — Score de calme : {stressScore:F0}/100");
    }

    void Update()
    {
        if (!isRecording) return;

        bpmHistory.Add(currentBPM);

        if (currentBPM > peakBPM)
            peakBPM = currentBPM;

        if (crowdManager != null && crowdManager.currentReaction == "Negative")
        {
            reactionLog.Add($"Réaction négative — BPM: {currentBPM:F0}");
        }
    }

    void CalculateResults()
    {
        if (bpmHistory.Count == 0) return;

        float total = 0f;
        foreach (float bpm in bpmHistory)
            total += bpm;

        averageBPM = total / bpmHistory.Count;
        stressScore = Mathf.Clamp(100f - (averageBPM - calmBPM) / (maxBPM - calmBPM) * 100f, 0f, 100f);

        Debug.Log($"BPM moyen : {averageBPM:F0}");
        Debug.Log($"BPM max : {peakBPM:F0}");
        Debug.Log($"Score de calme : {stressScore:F0}/100");

        foreach (string log in reactionLog)
            Debug.Log(log);
    }

    public string GetSessionSummary()
    {
        return $"BPM moyen: {averageBPM:F0} | BPM max: {peakBPM:F0} | Score: {stressScore:F0}/100 | Réactions négatives: {reactionLog.Count}";
    }
}