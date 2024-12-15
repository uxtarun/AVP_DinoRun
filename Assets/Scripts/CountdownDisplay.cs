using UnityEngine;
using UnityEngine.UI;  // Import UI namespace for Text component
using System.Collections;

public class CountdownDisplay : MonoBehaviour
{
    public Text countdownText;   // Reference to the Text UI element

    void Start()
    {
        // Start the countdown and text sequence on game start
        StartCoroutine(DisplayReadySetGo());
    }

    // Coroutine to manage the "Ready Set Go" display at specific times
    IEnumerator DisplayReadySetGo()
    {
        // Initially make sure the text is empty (or hidden)
        countdownText.text = "";

        // Show "Ready" from 0.37s to 1.05s (Duration: 0.68 sec)
        countdownText.text = "Ready";
        yield return new WaitForSecondsRealtime(0.68f);  // Wait for 0.68 seconds (1.05 - 0.37)
        countdownText.text = "";  // Clear the text

        // Show "Set" from 1.17s to 1.42s (Duration: 0.25 sec)
        yield return new WaitForSecondsRealtime(0.79f);  // Wait for 1.17 - 1.05 = 0.79 seconds
        countdownText.text = "Set";
        yield return new WaitForSecondsRealtime(0.25f);  // Wait for 1.42 - 1.17 = 0.25 seconds
        countdownText.text = "";  // Clear the text

        // Show "Go" from 1.99s to 2.70s (Duration: 0.71 sec)
        yield return new WaitForSecondsRealtime(0.57f);  // Wait for 1.99 - 1.42 = 0.57 seconds
        countdownText.text = "Go";
        yield return new WaitForSecondsRealtime(0.71f);   // Wait for 2.70 - 1.99 = 0.71 seconds
        countdownText.text = "";  // Clear the text (or it could stay empty)
    }
}
