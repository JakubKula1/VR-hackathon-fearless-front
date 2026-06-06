using UnityEngine;

public class SessionManager : MonoBehaviour
{
    private StressController stressController;
    private bool sessionRunning = false;

    void Start()
    {
        stressController = FindObjectOfType<StressController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!sessionRunning)
            {
                stressController?.StartSession();
                sessionRunning = true;
                Debug.Log("ESPACE — Session démarrée !");
            }
            else
            {
                stressController?.StopSession();
                sessionRunning = false;
                Debug.Log("ESPACE — Session arrêtée !");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            FindObjectOfType<AIFeedbackManager>()?.RequestFeedback();
            Debug.Log("Feedback IA demandé !");
        }
    }
}