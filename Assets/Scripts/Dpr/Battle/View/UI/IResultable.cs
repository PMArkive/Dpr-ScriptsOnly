namespace Dpr.Battle.View.UI
{
    public interface IResultable<TResultType>
    {
        bool IsValid { get; }
        TResultType Result { get; }
    }
}