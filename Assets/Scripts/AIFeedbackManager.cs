using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class AIFeedbackManager : MonoBehaviour
{
    private string apiKey;
    private string apiUrl = "https://api.groq.com/openai/v1/chat/completions";

    private StressController stressController;

    void Start()
    {
        stressController = FindObjectOfType<StressController>();

        string json = File.ReadAllText(Path.Combine(Application.dataPath, "secrets.json"));
        Secrets secrets = JsonUtility.FromJson<Secrets>(json);
        apiKey = secrets.groqApiKey;
    }

    public void RequestFeedback()
    {
        string summary = stressController.GetSessionSummary();
        StartCoroutine(SendToGroqAPI(summary));
    }

    IEnumerator SendToGroqAPI(string sessionSummary)
    {
        string prompt = $@"You are a public speaking coach. 
Here is the data from the VR training session:
{sessionSummary}

Give supportive and constructive feedback in 3 parts:
1. What went well
2. Difficult moments (stress peaks)
3. 2-3 concrete tips to better manage stress during a presentation

Reply in English, concisely (maximum 150 words).";

        var requestBody = new
        {
            model = "llama-3.3-70b-versatile",
            max_tokens = 1024,
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        string jsonBody = JsonConvert.SerializeObject(requestBody);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);

        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", $"Bearer {apiKey}");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            var response = JsonConvert.DeserializeObject<GroqResponse>(request.downloadHandler.text);
            string feedback = response.choices[0].message.content;
            Debug.Log("=== FEEDBACK IA ===");
            Debug.Log(feedback);
        }
        else
        {
            Debug.LogError($"Erreur API : {request.error}");
            Debug.LogError(request.downloadHandler.text);
        }
    }
}

[System.Serializable]
public class GroqResponse
{
    public List<GroqChoice> choices;
}

[System.Serializable]
public class GroqChoice
{
    public GroqMessage message;
}

[System.Serializable]
public class GroqMessage
{
    public string content;
}