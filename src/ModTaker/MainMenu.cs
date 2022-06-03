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

		// Menu state declarations
		public Dictionary<string, GameObject> menuObjects;

		public MenuState CurrentMenuState = MenuState.Main;
		public GameObject CurrentMenuCanvas;

		public void toMainMenu()
		{
			CurrentMenuState = MenuState.Main;
			CurrentMenuCanvas = menuObjects["Main"];

			CurrentMenuCanvas.SetActive(true);
		}

		public MainMenu()
		{
			menuObjects = new Dictionary<string, GameObject>()
			{{
				"Main", UI.Build("Main",  new UIItem[] {
					new UIButton()
					{
						Name = "TestButton",
						Text = "Test Button",
						Position = new Vector2(0, 0),
						Size = new Vector2(100, 100)
					}
				})
			}};

			// Default state is main menu
			toMainMenu();
		}
	}
}
