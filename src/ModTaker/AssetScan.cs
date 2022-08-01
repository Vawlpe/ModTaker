using UnityEngine;
using UnityEngine.UI;

namespace ModTaker
{
	public class AssetScanner
	{
		public static Dictionary<String, Sprite> ScanSpritesInScene(String sceneName)
		{
			var objs = from GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)) where go.scene.name == sceneName select go;
			var sprites = new Dictionary<String, Sprite>();
			foreach (GameObject go in objs)
			{
				try {
					foreach (var sr in go.GetComponentsInChildren<SpriteRenderer>())
						if (sr.sprite != null) sprites.Add(sr.sprite.name, sr.sprite);
					foreach (var im in go.GetComponentsInChildren<Image>())
						if (im.sprite != null) sprites.Add(im.sprite.name, im.sprite);
					foreach (var sr in go.GetComponents<SpriteRenderer>())
						if (sr.sprite != null) sprites.Add(sr.sprite.name, sr.sprite);
					foreach (var im in go.GetComponents<Image>())
						if (im.sprite != null) sprites.Add(im.sprite.name, im.sprite);
				} catch (System.Exception e) {
					Debug.LogError(e);
					continue;
				}
			}
			return sprites;
		} 
	}
}
