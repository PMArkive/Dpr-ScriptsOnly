using Dpr.SequenceEditor;

namespace Dpr.Sequence
{
	public interface ISequenceCallback
	{
		void CommandCallback(SequenceFile file, CommandParam param, bool isSkip);

		void CommandCallbackLate(SequenceFile file, CommandParam param, bool isSkip);
	}
}