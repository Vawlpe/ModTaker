using UnityEngine;

namespace ModTaker
{
	public class MainMenu
	{
		public enum MenuState
		{
			Main,
			ChapterSelect,
			Settings,
			Credits,
			Dialog,
			SceneTransition,
			Loading,
			Quit
		}

		public MenuState CurrentMenuState = MenuState.Main;
		public GameObject go = new GameObject();
		public void toMainMenu()
		{
			CurrentMenuState = MenuState.Main;
			go = MainMenuObject;
			go.name = "MainMenu";
		}

		public GameObject MainMenuObject = UI.Build(new UIItem[]
		{
			new UIButton() {
				Name = "TestButton",
				Position = new Vector2(100, 200),
				Size = new Vector2(150, 150),
				Text = "Test",
				FontSize = 30,
				Sprite = Resources.Load<Sprite>("Button")
			}
		});
	}
}
