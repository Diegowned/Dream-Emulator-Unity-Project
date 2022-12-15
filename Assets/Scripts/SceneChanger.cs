using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // An array of scene names to choose from
    public string[] sceneNames;
    public Animator sceneTransition;
    public float transitionTime = 1f;

    public void StartInteractCoroutine()
    {
         {
            // Start the scene transition
            StartCoroutine(TransitionScene());
         }


     IEnumerator TransitionScene()
    {
            Debug.Log("Generating Transition");
        sceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        // Choose a random scene from the array
        string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];

        // Load the new scene
        SceneManager.LoadScene(sceneName);

        yield return null;
    }
    }
}




