using System.Drawing;
using System.Runtime.InteropServices;
using ReClassNET.Controls;
using ReClassNET.UI;

namespace ReClassNET.Nodes
{
	public class Vector4Node : BaseMatrixNode
	{
		[StructLayout(LayoutKind.Explicit)]
		private readonly struct Vector4Data
		{
			[FieldOffset(0)]
			public readonly float X;
			[FieldOffset(4)]
			public readonly float Y;
			[FieldOffset(8)]
			public readonly float Z;
			[FieldOffset(12)]
			public readonly float W;
		}

		public override int ValueTypeSize => sizeof(float);

		public override int MemorySize => 4 * ValueTypeSize;

		public override void GetUserInterfaceInfo(out string name, out Image icon)
		{
			name = "Vector4";
			icon = Properties.Resources.B16x16_Button_Vector_4;
		}

		public override Size Draw(DrawContext context, int x2, int y2)
		{
			return DrawVectorType(context, x2, y2, "Vector4", (ref int x, ref int y) =>
			{
				var value = context.Memory.ReadObject<Vector4Data>(Offset);

				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, "(");
				x = AddText(context, x, y, context.Settings.ValueColor, 0, $"{value.X:0.000}");
				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(context, x, y, context.Settings.ValueColor, 1, $"{value.Y:0.000}");
				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(context, x, y, context.Settings.ValueColor, 2, $"{value.Z:0.000}");
				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(context, x, y, context.Settings.ValueColor, 3, $"{value.W:0.000}");
				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, ")");
			});
		}

		protected override int CalculateValuesHeight(DrawContext context)
		{
			return 0;
		}

		public override void Update(HotSpot spot)
		{
			base.Update(spot);

			Update(spot, 4);
		}
	}
}
