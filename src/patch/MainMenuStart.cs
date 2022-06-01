using ModTaker;

public class patch_MainMenuStart : MainMenuStart
{
	private extern void orig_Awake();
	private void Awake()
	{
		// Okay wait what? i end up with 2 objects in the scene
		// Both are called "New Game Object" and neither is attached to the mainMenuStart object
		// The first has the canvas components... and the second only has a transform
		// WTF Unity?
		var mm = new MainMenu();
		mm.toMainMenu();
		mm.go.transform.SetParent(this.transform);
	}
}
