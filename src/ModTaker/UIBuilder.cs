using UnityEngine;
using UnityEngine.UI;

namespace ModTaker.UI
{
	public class UICanvas
	{
		public static GameObject Build(String Name, UIItem[] uiItems)
		{
			var g = new GameObject();
			g.name = Name;
			
			var c = g.AddComponent<Canvas>();
			c.renderMode = RenderMode.ScreenSpaceOverlay;
			c.pixelPerfect = true;
			c.sortingOrder = 1;
			
			var cs = g.AddComponent<CanvasScaler>();
			cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			cs.referenceResolution = new Vector2(1920, 1080);
			cs.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
			
			var cr = g.AddComponent<GraphicRaycaster>();

			Array.ForEach(uiItems, uiItem => uiItem.Build().transform.SetParent(g.transform));
			return g;
		}
	}

	public class UIItem
	{
		public string Name      = String.Empty;
		public GameObject GO    = null;
		
		public Vector2 Position = Vector2.zero;
		public Vector2 Size     = Vector2.zero;
		public Vector2 Anchor   = Vector2.zero;
		public Vector2 Pivot    = Vector2.zero;
		public Vector2 Offset   = Vector2.zero;
		public Vector2 Rotation = Vector2.zero;
		public Vector2 Scale    = Vector2.one;

		public virtual GameObject Build()
		{
			GO = new GameObject();
			GO.name = Name;
			var RT = GO.AddComponent<RectTransform>();
			RT.anchorMin = Anchor;
			RT.anchorMax = Anchor;
			RT.pivot = Pivot;
			RT.anchoredPosition = Position + Offset;
			RT.sizeDelta = Size;
			RT.localScale = Scale;
			RT.localPosition = Position;
			RT.localRotation = Quaternion.Euler(Rotation);

			return GO;
		}
	}

	public class UIText : UIItem
	{
		public string Text = String.Empty;
		public Font Font = Resources.GetBuiltinResource<Font>("Arial.ttf");
		public Color Color = Color.white;
		public TextAnchor TextAnchor = TextAnchor.UpperLeft;
		public TextAlignment TextAlignment = TextAlignment.Left;
		public int FontSize = 12;
		public bool RichText = false;
		public bool RaycastTarget = false;

		public override GameObject Build()
		{
			GO = base.Build();

			Text text = GO.AddComponent<Text>();
			text.text = Text;
			text.font = Font;
			text.color = Color;
			text.alignment = TextAnchor;
			text.alignment = (TextAnchor)TextAlignment;
			text.fontSize = FontSize;
			text.supportRichText = RichText;
			text.raycastTarget = RaycastTarget;

			return GO;
		}
	}

	public class UIButton : UIItem
	{
		// Text
		public string Text = String.Empty;
		public Font Font = Resources.GetBuiltinResource<Font>("Arial.ttf");
		public Color Color = Color.white;
		public TextAnchor TextAnchor = TextAnchor.UpperLeft;
		public int FontSize = 12;
		public bool RichText = false;
		public bool RaycastTarget = false;

		// Image
		public Sprite Sprite = null;

		public override GameObject Build()
		{
			GO = base.Build();

			var b = GO.AddComponent<Button>();
			
			if (Sprite is not null)
			{
				var io = new GameObject(Name + "_Image");
				io.transform.SetParent(GO.transform);
				io.AddComponent<Image>().sprite = Sprite;
			}

			if (Text != String.Empty)
			{
				var to = new GameObject(Name + "_Text");
				to.transform.SetParent(GO.transform);
				var tc = to.AddComponent<Text>();
				tc.text = Text;
				tc.font = Font;
				tc.color = Color;
				tc.alignment = TextAnchor;
				tc.fontSize = FontSize;
				tc.supportRichText = RichText;
				tc.raycastTarget = RaycastTarget;
			}

			return GO;
		}
	}
}
