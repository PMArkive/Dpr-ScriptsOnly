using UnityEngine;

namespace Dpr.Battle.View
{
	public interface ITranslationObject
	{
		void SetTranslationVec(Vector3 translation);

		Vector3 GetTranslationVec();

		void SetTranslationOffset(Vector3 translation);

		Vector3 GetTranslationOffset();

		void SetScaleVec(Vector3 scale);

		Vector3 GetScaleVec();

		void SetScaleOffset(Vector3 scale);

		Vector3 GetScaleOffset();

		void SetRotationVec(Vector3 rot);

		Vector3 GetRotationVec();

		void SetRotationVecOffset(Vector3 rot);

		Vector3 GetRotationVecOffset();

		bool IsActive();

		void OnUpdatePreJob(float deltaTime);

		void OnUpdatePostJob(float deltaTime);
	}
}