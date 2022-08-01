using UnityEngine;

namespace ModTaker.UI.Helltaker
{
	public class Button : UIButton
	{
		public override GameObject Build()
		{
			this.Sprite = Global.Sprites["button0003"];
			return base.Build();
		}
	}
}
