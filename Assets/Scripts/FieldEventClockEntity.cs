using UnityEngine;

public class FieldEventClockEntity : FieldEventEntity
{
	public Transform HourHand;
	
	protected override void OnUpdate(float deltaTime)
	{
        base.OnUpdate(deltaTime);

		if (HourHand != null)
		{
			var z = Mathf.Lerp(0.0f, 360.0f, Mathf.InverseLerp(0.0f, 12.0f, Mathf.Repeat(GameManager.elapsedTimeOfDay, 12.0f)));
			var angles = HourHand.eulerAngles;
			angles.z = z;
			HourHand.eulerAngles = angles;
		}
    }
}