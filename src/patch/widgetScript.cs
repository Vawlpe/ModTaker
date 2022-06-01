#pragma warning disable CS0626 // orig_ method is marked external and has no attributes on it
using UnityEngine;
using UnityEngine.UI;
using MonoMod;

// Patch widgetScript to add a mod chapter button to the UI
public class patch_widgetScript : widgetScript
{
	[MonoModReplace]
	private int currentIndex = 666;
	[MonoModReplace]
	private int tempIndex;

	private extern void orig_OnEnable();
	private void OnEnable()
	{
		// Clone chapterDLC object into chapterMOD, changing it's name and localPosition
		var chapterMOD = UnityEngine.Object.Instantiate(transform.Find("chapterDLC").gameObject, transform).transform;
		chapterMOD.gameObject.name = "chapterMOD";
		chapterMOD.transform.localPosition = new Vector3(-675f, -325f, 0f);;

		// Change text properties of chapterMOD
		var chapterMOD_text = chapterMOD.Find("chapter_text").GetComponent<Text>();
		chapterMOD_text.text = "MOD";
		chapterMOD_text.fontSize = 28;
		chapterMOD_text.gameObject.transform.localPosition = new Vector3(-1f, -3f, 0f);
		
		// Add chapterMOD animator to chapterAnimator array
		chapterAnimator = chapterAnimator.Concat(new Animator[] {chapterMOD.GetComponent<Animator>()}).ToArray();

		// Add chapterMOD as a child of the widget Object
		chapterMOD.transform.SetParent(transform);

		// Call original OnEnable method
		orig_OnEnable();
	}

	// Replace Update with out own that takes into account the mod chapter button
	[MonoModReplace]
	private void Update()
	{
		if (Input.GetButton("Cancel"))
		{
			goalScript.BackFromWidget(1);
			base.gameObject.SetActive(value: false);
		}
		if (Input.GetButton("Submit"))
		{
			if (!submitBlock)
			{
				submitBlock = true;
				Manager.instance.RandomizeSfx(false, confirmSound);
				switch(currentIndex)
				{
					case 0:
						goalScript.BackFromWidget(2);
						base.gameObject.SetActive(false);
						break;
					case <9:
						goalScript.playerScript.DialogueRestart(currentIndex + 1);
						break;
					case 9:
						goalScript.playerScript.DialogueRestart(currentIndex + 6);
						break;
					case 10:
						goalScript.playerScript.DialogueRestart(currentIndex + 7);
						break;
					case 11:
						goalScript.BackFromWidget(1);
						base.gameObject.SetActive(false);
						break;
				}
			}
		}
		else submitBlock = false;
		switch (Input.GetAxis("Horizontal"))
		{
			case 0f:
				keyDown = false;
				break;
			case <0f:
				if (keyDown)
					break;

				keyDown = true;
				Manager.instance.RandomizeSfx(false, pickSound);

				if (currentIndex > 0)
					currentIndex--;
				else currentIndex = 11;
				
				ChapterChange();
				break;
			case >0f:
				if (keyDown)
					break;
				
				keyDown = true;
				Manager.instance.RandomizeSfx(false, pickSound);
				
				if (currentIndex < 11)
					currentIndex++;
				else currentIndex = 0;
				
				ChapterChange();
				break;
		}
	}

	// Replace ChapterChange with out own that takes into account the mod chapter button
	[MonoModReplace]
	private void ChapterChange()
	{
		chapterAnimator[tempIndex].SetBool("activeAnim", false);
		chapterAnimator[currentIndex].SetBool("activeAnim", true);
		tempIndex = currentIndex;
		chapterTitle.text = currentIndex switch
		{
			10 => Manager.instance.dlcTxt[0],
			11 => "ModTaker v0.1  |  1 Mod(s) Loaded",
			_ => chapterTxt[currentIndex]
		};
		chapterTitle.color = currentIndex >= 10 ? new Color(0.9f, 0.3f, 0.3f) : Color.white;
	}
}
#pragma warning restore CS0626 // orig_ method is marked external and has no attributes on it
