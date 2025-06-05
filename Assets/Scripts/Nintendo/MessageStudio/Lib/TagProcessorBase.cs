using System;
using System.Runtime.InteropServices;

namespace Nintendo.MessageStudio.Lib
{
    public abstract class TagProcessorBase
    {
        private const char ShiftIn = '\xf';
        private const char ShiftOut = '\xe';

        public void Process(IntPtr p)
        {
            int offset = 0;
            while (true)
            {
                var chara = ReadChar(p, offset);
                switch (chara)
                {
                    case ShiftIn:
                        offset += 2;
                        break;

                    case ShiftOut:
                        var group = (ushort)Marshal.ReadInt16(p, offset + 2);
                        var tag = (ushort)Marshal.ReadInt16(p, offset + 4);
                        var size = Marshal.ReadInt16(p, offset + 6);
                        offset += 8;

                        var param = new byte[size];
                        for (int i=0; i!=size; i++)
                            param[i] = Marshal.ReadByte(p, offset + i);

                        offset += size;
                        ProcessTag(group, tag, param);
                        break;

                    case '\0':
                        ProcessEnd();
                        return;

                    default:
                        ProcessChar(chara);
                        offset += 2;
                        break;
                }
            }
        }

        private void ProcessTag(ushort group, ushort tag, byte[] param)
        {
            if (group == 0)
                ProcessSystemTag(tag, param);
            else
                ProcessCustomTag(new CustomTagInfo(group, tag, param));
        }

        private void ProcessSystemTag(ushort tag, byte[] param)
        {
            switch (tag)
            {
                case 0:
                    ProcessRubyTag(new RubyTagInfo(param));
                    break;

                case 1:
                    ProcessFontTag(new FontTagInfo(param));
                    break;

                case 2:
                    ProcessSizeTag(new SizeTagInfo(param));
                    break;

                case 3:
                    ProcessColorTag(new ColorTagInfo(param));
                    break;

                case 4:
                    ProcessPageBreakTag(new PageBreakTagInfo());
                    break;

                default:
                    throw new InvalidOperationException("Unkwon System Tag ID : " + tag);
            }
        }

        protected abstract void ProcessChar(char c); // 0x170

        protected abstract void ProcessRubyTag(RubyTagInfo rubyTagInfo); // 0x180

        protected abstract void ProcessFontTag(FontTagInfo fontTagInfo); // 0x190

        protected abstract void ProcessSizeTag(SizeTagInfo sizeTagInfo); // 0x1a0

        protected abstract void ProcessColorTag(ColorTagInfo colorTagInfo); // 0x1b0

        protected abstract void ProcessPageBreakTag(PageBreakTagInfo pageBreakTagInfo); // 0x1c0

        protected abstract void ProcessCustomTag(CustomTagInfo tagInfo); // 0x1d0

        protected abstract void ProcessEnd(); // 0x1e0

        private char ReadChar(IntPtr p, int offset)
        {
            var byte1 = Marshal.ReadByte(p, offset);
            var byte2 = Marshal.ReadByte(p, offset + 1);
            var value = byte2 * 256 + byte1;
            return Convert.ToChar(value);
        }
    }
}