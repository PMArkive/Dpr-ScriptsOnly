using System;

namespace Dpr.SequenceEditor
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MacroAttribute : Attribute
    {
	    public CommandNo CommandNo { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string PreFunc { get; set; }

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