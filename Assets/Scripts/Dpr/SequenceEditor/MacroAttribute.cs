using System;

namespace Dpr.SequenceEditor
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MacroAttribute : Attribute
    {
	    public CommandNo CommandNo { get; private set; }
        public string Color { get; private set; }
        public string Type { get; private set; }
        public string PreFunc { get; private set; }

        public MacroAttribute(CommandNo command)
        {
            CommandNo = command;
        }

        public MacroAttribute(CommandNo command, string color, string type, string preFunc)
        {
            CommandNo = command;
            Color = color;
            Type = type;
            PreFunc = preFunc;
        }
    }
}