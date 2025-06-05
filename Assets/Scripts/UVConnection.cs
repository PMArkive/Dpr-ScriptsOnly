using SmartPoint.AssetAssistant;
using System;
using UnityEngine;

public sealed class UVConnection : MonoBehaviour
{
    private MaterialPropertyBlock propertyBlock;
    [SerializeField]
    private Property Property00;
    [SerializeField]
    private Property Property01;
    [SerializeField]
    private Property Property02;
    [SerializeField]
    private Property Property03;

    public Property this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return Property00;

                case 1:
                    return Property01;

                case 2:
                    return Property02;

                case 3:
                    return Property03;

                default: // I think this is properly in the original code?
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    Property00 = value;
                    break;

                case 1:
                    Property01 = value;
                    break;

                case 2:
                    Property02 = value;
                    break;

                case 3:
                    Property03 = value;
                    break;
            }
        }
    }

    private void OnEnable()
    {
        propertyBlock = new MaterialPropertyBlock();

        Sequencer.earlyLateUpdate -= OnUpdate;
        Sequencer.earlyLateUpdate += OnUpdate;

        Property00.Reset();
        Property01.Reset();
        Property02.Reset();
        Property03.Reset();
    }

    private void OnDisable()
    {
        Sequencer.earlyLateUpdate -= OnUpdate;

        Property00.Clear();
        Property01.Clear();
        Property02.Clear();
        Property03.Clear();

        propertyBlock = null;
    }

    private void OnUpdate(float deltaTime)
    {
        if (enabled)
        {
            Property00.Update(propertyBlock);
            Property01.Update(propertyBlock);
            Property02.Update(propertyBlock);
            Property03.Update(propertyBlock);
        }
    }

    [Serializable]
    public struct Property
    {
	    [SerializeField]
        public Renderer renderer;
        [SerializeField]
        public int materialIndex;
        [SerializeField]
        public Vector2 baseUV;
        [SerializeField]
        public Vector2 offsetUV;
        [SerializeField]
        public string propertyName;
        private int propertyID;

        public void Reset()
        {
            if (renderer != null)
                propertyID = Shader.PropertyToID(propertyName);
        }

        public void Update(MaterialPropertyBlock propertyBlock)
        {
            if (renderer == null || propertyBlock == null || propertyID == 0)
                return;

            renderer.GetPropertyBlock(propertyBlock, materialIndex);
            propertyBlock.SetVector(propertyID, -(baseUV + offsetUV));
            renderer.SetPropertyBlock(propertyBlock, materialIndex);
        }

        public void Clear()
        {
            if (renderer != null)
                renderer.SetPropertyBlock(null, materialIndex);
        }
    }
}