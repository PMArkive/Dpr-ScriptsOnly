using System;

namespace Dpr.Battle.View.UI
{
    public interface IBattleUIButton<T>
    {
        int Index { get; }
        bool IsSelected { get; }

        T SetOnSelected(Action onSelected);

        T SetOnSubmit(Action onSubmit);

        bool Submit();
    }
}