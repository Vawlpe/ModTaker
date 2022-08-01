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

			Array.ForEach(menuObjects.Values.ToArray(), (GameObject go) => go.SetActive(false));
			CurrentMenuCanvas.SetActive(true);
		}

		public MainMenu()
		{
			menuObjects = new Dictionary<string, GameObject>()
			{{
				"Main", UI.UICanvas.Build("Main",  new UI.UIItem[] {
					new UI.Helltaker.Button()
					{
						Name = "TestButton",
						Text = "Test Button",
						Position = new Vector2(-400, 40),
						Size = new Vector2(1000, 100),
						FontSize = 30
					}
				})
			}};

			// Default state is main menu
			toMainMenu();
		}
	}
}
