using UnityEngine;

namespace Dpr.Spline
{
	public static class Bezier
	{
		public static Vector3 CubicBezier(Vector3 pv0, Vector3 pv1, Vector3 pv2, Vector3 pv3, float ft)
		{
			var inverseFt = 1.0f - ft;

			var pv0Factor =        inverseFt * inverseFt * inverseFt;
			var pv1Factor = 3.0f * ft        * inverseFt * inverseFt;
			var pv2Factor = 3.0f * ft        * ft        * inverseFt;
			var pv3Factor =        ft        * ft        * ft;

			return new Vector3(pv0.x * pv0Factor + pv1.x * pv1Factor + pv2.x * pv2Factor + pv3.x * pv3Factor,
                               pv0.y * pv0Factor + pv1.y * pv1Factor + pv2.y * pv2Factor + pv3.y * pv3Factor,
                               pv0.z * pv0Factor + pv1.z * pv1Factor + pv2.z * pv2Factor + pv3.z * pv3Factor);
		}
	}
}