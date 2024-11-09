using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SaveScore : MonoBehaviour
{
   [SerializeField] int score;

    public void SetScore(int x) { 
        score=x;
    }

    // Call this function to send the score to WordPress
    public void SaveScoreToWordPress()
    {
        StartCoroutine(SendScore(score));
    }

    private IEnumerator SendScore(int score)
    {
        // URL to PHP script on the server
        string url = "http://localhost/wk1/wp-content/themes/twentytwentyfour/save_score.php";

        // Prepare the form data
        WWWForm form = new WWWForm();
        form.AddField("score", score);

        // Send POST request to PHP script
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Score updated successfully: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error updating score: " + www.error);
            }
        }
    }
}