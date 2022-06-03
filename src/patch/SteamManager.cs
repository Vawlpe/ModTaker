#pragma warning disable CS8618, CS0626 // Disable warnings.
using G = ModTaker.Global;

// Disable SteamManager without removing it.
public class patch_SteamManager : SteamManager
{
	protected extern void orig_Awake();
	protected new void Awake()
	{
		if (!G.EnableSteam) this.enabled = false;
	}

	protected extern void orig_OnEnable();
	protected new void OnEnable()
	{
		if (!G.EnableSteam) this.enabled = false;
	}

	protected extern void orig_Update();
	protected new void Update()
	{
		if (!G.EnableSteam) this.enabled = false;
	}
}
#pragma warning restore CS8618 // Re-enable warnings.
