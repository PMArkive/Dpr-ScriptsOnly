using UnityEngine;

namespace Effect
{
	public class MaterialController : MonoBehaviour
	{
		[SerializeField]
		public Vector4[] _UvScroll0 = new Vector4[3]; // TODO: Find constants for these?
		[SerializeField]
		public Vector4[] _UvScroll1 = new Vector4[3];
        [SerializeField]
		public Vector4[] _UvRotation = new Vector4[3];
        [SerializeField]
		public Vector4[] _UvScale0 = new Vector4[3];
        [SerializeField]
		public Vector4[] _UvScale1 = new Vector4[3];
        [SerializeField]
		public Color _MulColor = Color.white;

		private ParticleSystem _particleSystem;
		private ParticleSystemRenderer _renderer;
		private MaterialPropertyBlock _propertyBlock;
		private Random _random;

		private static int _id_Texture0_ST = Shader.PropertyToID("_Texture0_ST");
		private static int _id_Texture1_ST = Shader.PropertyToID("_Texture1_ST");
        private static int _id_Texture2_ST = Shader.PropertyToID("_Texture2_ST");
        private static int _id_UvScroll0 = Shader.PropertyToID("_UvScroll0");
        private static int _id_UvScroll1 = Shader.PropertyToID("_UvScroll1");
        private static int _id_UvScroll2 = Shader.PropertyToID("_UvScroll2");
        private static int _id_UvRotation0 = Shader.PropertyToID("_UvRotation0");
        private static int _id_UvRotation1 = Shader.PropertyToID("_UvRotation1");
        private static int _id_UvScale0 = Shader.PropertyToID("_UvScale0");
        private static int _id_UvScale1 = Shader.PropertyToID("_UvScale1");
        private static int _id_UvScale2 = Shader.PropertyToID("_UvScale2");
        private static int _id_MulColorEnabled = Shader.PropertyToID("_MulColorEnabled");
        private static int _id_MulColor = Shader.PropertyToID("_MulColor");

        // TODO
        public ParticleSystem GetParticleSystem() { return default; }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void Start() { }
		
		// TODO
		public void CreateRandom() { }
		
		// TODO
		public void CreateRandom(int seed) { }
		
		// TODO
		public float RandomRange(float min, float max) { return default; }
		
		// TODO
		public void SetupProperty() { }
		
		// TODO
		public void SetMultiplyColor(Color color) { }
	}
}