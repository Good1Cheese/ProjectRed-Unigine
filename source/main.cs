using System;
using Unigine;

namespace UnigineApp
{
	class UnigineApp
	{
		[STAThread]
		static void Main(string[] args)
		{
			Engine.Init(args);

			AppSystemLogic systemLogic = new();
			AppWorldLogic worldLogic = new();
			AppEditorLogic editorLogic = new();

			Engine.Main(systemLogic, worldLogic, editorLogic);

			Engine.Shutdown();
		}
	}
}