using System.Collections.Generic;
using UnityEngine;

public class PetrifyUpdater : MonoBehaviour
{
	private static readonly int _noiseFactorID = Shader.PropertyToID("_PetrifyNoiseFactor");
	private static readonly int _triPlanarScaleID = Shader.PropertyToID("_PetrifyTriPlanarScale");
    private static readonly int _textureOffsetID = Shader.PropertyToID("_PetrifyTextureOffset");
    private static readonly int _disributionID = Shader.PropertyToID("_PetrifyDistribution");
    private static readonly int _edgeDetectionID = Shader.PropertyToID("_PetrifyEdgeDetectionScale");
    private static readonly int _colorWeightID = Shader.PropertyToID("_PetrifyColorWeight");
    private static readonly int _bumpScaleID = Shader.PropertyToID("_PetrifyBumpScale");
	private static readonly int _cosinePowerID = Shader.PropertyToID("_PetrifyCosinePower");
    private static readonly int _specularScaleID = Shader.PropertyToID("_PetrifySpecularScale");
    private static readonly int _glossyID = Shader.PropertyToID("_PetrifyGlossy");
    private static readonly int _reflecivityID = Shader.PropertyToID("_PetrifyReflectivity");
    private static readonly int _colorMapID = Shader.PropertyToID("_PetrifyAlbedoTex");
    private static readonly int _bumpMapID = Shader.PropertyToID("_PetrifyBumpTex");
    private static readonly int _specularMapID = Shader.PropertyToID("_PetrifySpecularTex");
    private static readonly int _ambientMapID = Shader.PropertyToID("_PetrifyAmbientTex");

    public PetrifyData.MaterialData materialData;
	public List<Material> materials = new List<Material>();
	
	// TODO
	public void LateUpdate() { }
	
	// TODO
	public static void SetParameters(PetrifyData.MaterialData materialData, List<Material> materials) { }
}