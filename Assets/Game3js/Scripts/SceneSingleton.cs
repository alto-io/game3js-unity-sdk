using UnityEngine;

public class SceneSingleton<T> : MonoBehaviour where T : UnityEngine.Object
{
	static T __instance;

	public static T Instance {
		get {
			if (__instance == null)
				__instance = Object.FindObjectOfType (typeof(T)) as T;
			
			return __instance;
		}
	}
}

