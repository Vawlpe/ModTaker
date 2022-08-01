using ModTaker;
using UnityEngine;
using UnityEngine.SceneManagement;

public class patch_MainMenuStart : MainMenuStart
{
	private extern void orig_Awake();
	private void Awake()
	{
		orig_Awake();
		Global.Sprites = AssetScanner.ScanSpritesInScene(SceneManager.GetActiveScene().name);
		Debug.Log("Found " + Global.Sprites.Count + " sprites");
		foreach (var s in Global.Sprites)
		{
			Debug.Log("Sprite: " + s.ToString());
		}
		
		var mm = new MainMenu();
		mm.toMainMenu();
		mm.CurrentMenuCanvas.transform.SetParent(this.transform);
	}
}
