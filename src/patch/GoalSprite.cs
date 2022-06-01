#pragma warning disable CS0626 // orig_ method is marked external and has no attributes on it.
public class patch_GoalSprite : GoalSprite
{
	private extern void orig_Start();
	private void Start()
	{
		orig_Start();
		// Stupid dialog manip, don't do this.
		// I'll implement Diannex <-> DialogElement[] + String[] conversion later
		// to simplify writing dialogue without scene access.
		txt[19] = "You find yourself surrounded by the void.\n But something is different...";
		txt[1] = "Greetings little one. It is just I, good old Beelzebub.\nChanging the fabric of reality? I'm afraid not.";
		txt[2] = "Certainly interesting, but it won't get you out of here.";
	}
}
#pragma warning restore CS0626 // orig_ method is marked external and has no attributes on it.
