using ModTaker;

public class patch_MainMenuStart : MainMenuStart
{
	private extern void orig_Awake();
	private void Awake()
	{
		orig_Awake();

		// This is meant to give us the following structure:
		// - mainMenuStarter (this)
		// -- Main
		// --- TestButton
		// Instead all 3 of these objects are at the global level...
		// wtf Unity? I explicitly set the parents of all of these objects so why does it not work?
		var mm = new MainMenu();
		mm.toMainMenu();
		mm.CurrentMenuCanvas.transform.SetParent(this.transform);
	}
}
