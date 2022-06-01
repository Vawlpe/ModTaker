#pragma warning disable CS8618, CS0626 // Disable warnings.
using MonoMod;
using G = ModTaker.Global;

// Disable SteamManager without removing it.
public class patch_SteamManager : SteamManager
{
	[MonoModReplace]
	protected static bool s_EverInialized = false;

	[MonoModPublic]
	public static new SteamManager Instance;

	protected extern void orig_Awake();
	protected new void Awake()
	{
		if (G.EnableSteam) orig_Awake();
	}

	protected extern void orig_OnEnable();
	protected new void OnEnable()
	{
		if (G.EnableSteam) orig_OnEnable();
	}

	protected extern void orig_Update();
	protected new void Update()
	{
		if (G.EnableSteam) orig_Update();
	}
}
#pragma warning restore CS8618 // Re-enable warnings.
