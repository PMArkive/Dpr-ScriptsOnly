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
		private System.Random _random;

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

        public ParticleSystem GetParticleSystem()
		{
			if (_renderer == null)
				_renderer = GetComponent<ParticleSystemRenderer>();

			if (_particleSystem == null)
                _particleSystem = GetComponent<ParticleSystem>();

			return _particleSystem;
		}
		
		private void OnEnable()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _renderer = GetComponent<ParticleSystemRenderer>();
        }
		
		private void OnDisable()
		{
			_renderer = null;
			_particleSystem = null;
		}
		
		private void OnDestroy()
        {
            _particleSystem = null;
            _renderer = null;
			_random = null;

			_propertyBlock?.Clear();
			_propertyBlock = null;
        }
		
		private void Start()
		{
			CreateRandom((int)_particleSystem.randomSeed);
			SetupProperty();
		}
		
		public void CreateRandom()
		{
            _random = new System.Random();
        }
		
		public void CreateRandom(int seed)
		{
			_random = new System.Random(seed);
		}
		
		public float RandomRange(float min, float max)
		{
			return Mathf.Lerp(min, max, _random.Next() / int.MaxValue);
		}
		
		public void SetupProperty()
		{
			if (_propertyBlock == null)
				_propertyBlock = new MaterialPropertyBlock();

			if (_random == null)
				_random = new System.Random();

			if (_renderer == null)
				return;

			_propertyBlock.SetVector(_id_UvScroll0, new Vector4(
                _UvScroll0[0].x + RandomRange(-_UvScroll0[0].z, _UvScroll0[0].z),
                _UvScroll0[0].y + RandomRange(-_UvScroll0[0].w, _UvScroll0[0].w),
                _UvScroll1[0].x,
                _UvScroll1[0].y
            ));

            _propertyBlock.SetVector(_id_UvScroll1, new Vector4(
                _UvScroll0[1].x + RandomRange(-_UvScroll0[1].z, _UvScroll0[1].z),
                _UvScroll0[1].y + RandomRange(-_UvScroll0[1].w, _UvScroll0[1].w),
                _UvScroll1[1].x,
                _UvScroll1[1].y
            ));

            _propertyBlock.SetVector(_id_UvScroll2, new Vector4(
                _UvScroll0[2].x + RandomRange(-_UvScroll0[2].z, _UvScroll0[2].z),
                _UvScroll0[2].y + RandomRange(-_UvScroll0[2].w, _UvScroll0[2].w),
                _UvScroll1[2].x,
                _UvScroll1[2].y
            ));

            _propertyBlock.SetVector(_id_UvRotation0, new Vector4(
                _UvRotation[0].x + RandomRange(-_UvRotation[0].y, _UvRotation[0].y),
                _UvRotation[0].z,
                _UvRotation[1].x + RandomRange(-_UvRotation[1].y, _UvRotation[1].y),
                _UvRotation[1].z
            ));

            _propertyBlock.SetVector(_id_UvRotation1, new Vector4(
                _UvRotation[2].x + RandomRange(-_UvRotation[2].y, _UvRotation[2].y),
                _UvRotation[2].z,
                0.0f,
				0.0f
            ));

            _propertyBlock.SetVector(_id_UvScale0, new Vector4(
                _UvScale0[0].x + RandomRange(-_UvScale0[0].z, _UvScale0[0].z),
                _UvScale0[0].y + RandomRange(-_UvScale0[0].w, _UvScale0[0].w),
                _UvScale1[0].x,
                _UvScale1[0].y
            ));

            _propertyBlock.SetVector(_id_UvScale1, new Vector4(
                _UvScale0[1].x + RandomRange(-_UvScale0[1].z, _UvScale0[1].z),
                _UvScale0[1].y + RandomRange(-_UvScale0[1].w, _UvScale0[1].w),
                _UvScale1[1].x,
                _UvScale1[1].y
            ));

            _propertyBlock.SetVector(_id_UvScale2, new Vector4(
                _UvScale0[2].x + RandomRange(-_UvScale0[2].z, _UvScale0[2].z),
                _UvScale0[2].y + RandomRange(-_UvScale0[2].w, _UvScale0[2].w),
                _UvScale1[2].x,
                _UvScale1[2].y
            ));

			SetMultiplyColor(_MulColor);
			_renderer.SetPropertyBlock(_propertyBlock);
        }
		
		public void SetMultiplyColor(Color color)
		{
			_MulColor = color;

			if (_renderer == null)
				return;

			if (_propertyBlock == null)
				SetupProperty();

			_propertyBlock.SetColor(_id_MulColor, _MulColor);
			_renderer.SetPropertyBlock(_propertyBlock);
		}
	}
}