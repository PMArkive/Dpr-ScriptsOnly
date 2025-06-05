namespace Dpr.EvScript
{
    public class EvScriptData
    {
        public EvData EvData;
        public int LabelIndex;
        public int CommandIndex;
        public int RetIndex;

        public EvData.Script GetScript { get => EvData.Scripts[LabelIndex]; }

        public EvScriptData(EvData ev)
        {
            EvData = ev;
        }

        public int FindLabelIndex(string label)
        {
            return EvData.Scripts.FindIndex(data => data.Label == label);
        }

        public EvData.Script FindLabelScript(string label)
        {
            return EvData.Scripts.Find(data => data.Label == label);
        }

        public void Destroy()
        {
            EvData = null;
        }
    }
}
