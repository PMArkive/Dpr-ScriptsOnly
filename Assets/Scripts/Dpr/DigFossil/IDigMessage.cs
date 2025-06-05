using System;

namespace Dpr.DigFossil
{
	public interface IDigMessage
	{
		void ShowStartMessage(int depositNum, Action onFinishedShowAllMessage, Action onFinishedCloseWindow);

		void ShowResultMessage(bool bIsDigOutAllItems, Action onFinishedShowAllMessage, Action onFinishedCloseWindow);

		void ShowResultCommonItemMessage(int labelId, Action onFinishedShowAllMessage, Action onFinishedCloseWindow);

		void ShowResultStoneBoxMessage(short boxId, Action onFinishedShowAllMessage, Action onFinishedCloseWindow);

		void ShowStoneBoxOpenMessage(Action onFinishedShowAllMessage, Action onFinishedCloseWindow);

		void ShowStatueGetMessage(int labelId, Action onFinishedShowAllMessage, Action onFinishedCloseWindow);

		void ShowItemMaxMessage(Action onFinishedShowAllMessage, Action onFinishedCloseWindow);

		void ShowUgItemMaxMessage(Action onFinishedShowAllMessage, Action onFinishedCloseWindow);

		void Close();
	}
}