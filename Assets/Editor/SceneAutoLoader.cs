﻿using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
static class SceneAutoLoader {

	static string sceneToLoad = "Assets/Scenes/Menu/Menu.unity";
	private static string PreviousScenePath {

		get {
			
			return EditorPrefs.GetString("SceneAutoLoader.PreviousScenePath", SceneManager.GetActiveScene().path);
		}

		set {

			EditorPrefs.SetString("SceneAutoLoader.PreviousScenePath", value);
		}
	}

	static SceneAutoLoader() {

        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state) {
		if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode) {

			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {

				PreviousScenePath = SceneManager.GetActiveScene().path;
				EditorSceneManager.OpenScene(sceneToLoad);
			}

			return;
        }

		if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode) {

			EditorSceneManager.OpenScene(PreviousScenePath);
		}
	}
}