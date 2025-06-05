using SmartPoint.AssetAssistant.UnityExtensions;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dpr.Battle.View.Systems
{
    public struct ShadowCastObject
    {
        public static readonly string[] PROCESS_SHADER_NAMES = new string[2]
        {
            "Mitake/MitakeStandardBumpShader", "Delphis/Character/Standard",
        };

	    public Transform originObject { get; set; }
        public Renderer[] renderers { get; set; }
        public ShadowCastingMode[] initializeModes { get; set; }
        public bool isDelete { get; set; }
        public Pair<Renderer, Renderer>[] linkRenderes { get; set; }

        public static ShadowCastObject Factory(Transform originObject, Renderer[] renderers)
        {
            var shadowObj = new ShadowCastObject();
            shadowObj.originObject = originObject;
            shadowObj.isDelete = false;
            shadowObj.renderers = new Renderer[renderers.Length];
            shadowObj.initializeModes = new ShadowCastingMode[renderers.Length];
            shadowObj.linkRenderes = new Pair<Renderer, Renderer>[renderers.Length];
            for (int i=0; i<renderers.Length; i++)
            {
                shadowObj.renderers[i] = renderers[i];
                shadowObj.initializeModes[i] = renderers[i].shadowCastingMode;
            }

            return shadowObj;
        }

        public void Initialize(Material shadowCastMaterial)
        {
            for (int i=0; i<renderers.Length; i++)
            {
                var mats = renderers[i].sharedMaterials;
                for (int j=0; j<mats.Length; j++)
                {
                    var sharedMaterial = mats[j];
                    if (Array.Find(PROCESS_SHADER_NAMES, x => x == sharedMaterial.shader.name) == null)
                        initializeModes[i] = ShadowCastingMode.Off;
                }

                var newRenderer = UnityEngine.Object.Instantiate(renderers[i], originObject);
                newRenderer.gameObject.layer = LayerMask.NameToLayer("Field");

                var oldMats = newRenderer.materials;
                newRenderer.materials = Enumerable.Repeat(shadowCastMaterial, newRenderer.materials.Length).ToArray();

                newRenderer.shadowCastingMode = initializeModes[i];
                linkRenderes[i] = new Pair<Renderer, Renderer>(renderers[i], newRenderer);

                for (int j=0; j<oldMats.Length; j++)
                    UnityEngine.Object.DestroyImmediate(oldMats[j]);
            }

            SetDraw(true);
        }

        public void UnInitialize()
        {
            originObject = null;
            renderers = null;
            
            for (int i=0; i<linkRenderes.Length; i++)
            {
                if (linkRenderes[i].Second != null && linkRenderes[i].Second.gameObject != null)
                {
                    var mats = linkRenderes[i].Second.materials;
                    for (int j=0; j<mats.Length; j++)
                        UnityEngine.Object.DestroyImmediate(mats[j]);

                    linkRenderes[i].Second = null;
                }
            }

            linkRenderes = null;
        }

        public void SetDraw(bool isDraw)
        {
            for (int i=0; i<linkRenderes.Length; i++)
            {
                if (linkRenderes[i] != null && linkRenderes[i].Second != null)
                    linkRenderes[i].Second.SetActive(isDraw);
            }
        }

        public void Draw()
        {
            if (originObject == null)
            {
                isDelete = true;
            }
            else
            {
                for (int i=0; i<linkRenderes.Length; i++)
                {
                    if (linkRenderes[i].First != null && linkRenderes[i].First != linkRenderes[i].Second)
                        linkRenderes[i].Second.enabled = linkRenderes[i].First.enabled;
                }
            }
        }
    }
}
