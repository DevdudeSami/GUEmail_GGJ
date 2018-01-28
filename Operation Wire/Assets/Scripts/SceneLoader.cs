using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

    // Used to check whether or not the current scene should be loading a new scene
    private bool loadScene = false;

    // Exposed in the Inspector, stores the desired scene to be loaded
    [SerializeField]
    private int scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (loadScene == false)
        {
            loadScene = true;
            StartCoroutine(LoadNewScene());
        }
	}

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(5);

        // Uses the Application class in Unity to call a method which takes a scene number
        AsyncOperation async = Application.LoadLevelAsync(scene);
        while (!async.isDone)
        {
            yield return null;
        }
    }
}