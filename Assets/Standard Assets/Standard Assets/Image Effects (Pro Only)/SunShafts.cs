using UnityEngine;

public enum SunShaftsResolution
{
    Low = 0,
    Normal = 1,
	High = 2,
}
	
public enum ShaftsScreenBlendMode
{
	Screen = 0,
	Add = 1,	
}	
		
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Rendering/Sun Shafts")]
[RequireComponent(typeof(Camera))]
public class SunShafts : PostEffectsBaseCS
{		
	public SunShaftsResolution Resolution = SunShaftsResolution.Normal;
	public ShaftsScreenBlendMode ScreenBlendMode = ShaftsScreenBlendMode.Screen;
	
	public Transform SunTransform;
	public int RadialBlurIterations = 2;
	public Color SunColor = Color.white;
	public float SunShaftBlurRadius = 2.5f;
	public float SunShaftIntensity = 1.15f;
	public float UseSkyBoxAlpha = 0.75f;
	
	public float MaxRadius = 0.75f;
	
	public bool UseDepthTexture = true;
	
	public Shader SunShaftsShader;
	private Material _sunShaftsMaterial;	
	
	public Shader SimpleClearShader;
	private Material _simpleClearMaterial;


    //
	public override bool CheckResources()
    {	
		CheckSupport(UseDepthTexture);
		
		_sunShaftsMaterial = CheckShaderAndCreateMaterial(SunShaftsShader, _sunShaftsMaterial);
		_simpleClearMaterial = CheckShaderAndCreateMaterial(SimpleClearShader, _simpleClearMaterial);
		
		if(!IsSupported)
        {
            ReportAutoDisable();
        }

		return IsSupported;				
	}
	
    //
	public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {	
		if(!CheckResources())
        {
			Graphics.Blit(source, destination);
			return;
		}
				
		// we actually need to check this every frame
		if(UseDepthTexture)
        {
            GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;	
		}

        int divider = 4;

        if (Resolution == SunShaftsResolution.Normal)
        {
            divider = 2;
        }
        else if (Resolution == SunShaftsResolution.High)
        {
            divider = 1;
        }

	    Vector3 v = SunTransform ? GetComponent<Camera>().WorldToViewportPoint(SunTransform.position) : new Vector3(0.5f, 0.5f, 0.0f);

		int rtW = source.width / divider;
		int rtH = source.height / divider;

	    RenderTexture lrDepthBuffer = RenderTexture.GetTemporary(rtW, rtH, 0);
		
		// mask out everything except the skybox
		// we have 2 methods, one of which requires depth buffer support, the other one is just comparing images
		
		_sunShaftsMaterial.SetVector("_BlurRadius4", new Vector4 (1.0f, 1.0f, 0.0f, 0.0f) * SunShaftBlurRadius );
		_sunShaftsMaterial.SetVector("_SunPosition", new Vector4 (v.x, v.y, v.z, MaxRadius));		
		_sunShaftsMaterial.SetFloat("_NoSkyBoxMask", 1.0f - UseSkyBoxAlpha);	
		
		if (!UseDepthTexture)
        {		
			RenderTexture tmpBuffer = RenderTexture.GetTemporary(source.width, source.height, 0);					
			RenderTexture.active = tmpBuffer;
			GL.ClearWithSkybox(false, GetComponent<Camera>());
			
			_sunShaftsMaterial.SetTexture("_Skybox", tmpBuffer);
			Graphics.Blit(source, lrDepthBuffer, _sunShaftsMaterial, 3);		
			RenderTexture.ReleaseTemporary (tmpBuffer);				
		}
		else
        {		
			Graphics.Blit(source, lrDepthBuffer, _sunShaftsMaterial, 2);
		}
				
        // paint a small black small border to get rid of clamping problems
		DrawBorder(lrDepthBuffer, _simpleClearMaterial);
		        			
		// radial blur:
						
		RadialBlurIterations = Mathf.Clamp(RadialBlurIterations, 1, 4);
				
		float ofs = SunShaftBlurRadius * (1.0f / 768.0f);
		
		_sunShaftsMaterial.SetVector("_BlurRadius4", new Vector4(ofs, ofs, 0.0f, 0.0f));			
		_sunShaftsMaterial.SetVector("_SunPosition", new Vector4(v.x, v.y, v.z, MaxRadius));				
				
		for (int it2 = 0; it2 < RadialBlurIterations; it2++ )
        {
			// each iteration takes 2 * 6 samples
			// we update _BlurRadius each time to cheaply get a very smooth look
			
			RenderTexture lrColorB = RenderTexture.GetTemporary(rtW, rtH, 0);
			Graphics.Blit(lrDepthBuffer, lrColorB, _sunShaftsMaterial, 1);
			RenderTexture.ReleaseTemporary(lrDepthBuffer);
			ofs = SunShaftBlurRadius * (((it2 * 2.0f + 1.0f) * 6.0f)) / 768.0f;
			_sunShaftsMaterial.SetVector("_BlurRadius4", new Vector4 (ofs, ofs, 0.0f, 0.0f) );			
			
			lrDepthBuffer = RenderTexture.GetTemporary(rtW, rtH, 0);
			Graphics.Blit (lrColorB, lrDepthBuffer, _sunShaftsMaterial, 1);		
			RenderTexture.ReleaseTemporary (lrColorB);
			ofs = SunShaftBlurRadius * (((it2 * 2.0f + 2.0f) * 6.0f)) / 768.0f;			
			_sunShaftsMaterial.SetVector("_BlurRadius4", new Vector4 (ofs, ofs, 0.0f, 0.0f) );
		}		
		
		// put together:

        if (v.z >= 0.0f)
        {
            _sunShaftsMaterial.SetVector("_SunColor", new Vector4(SunColor.r, SunColor.g, SunColor.b, SunColor.a) * SunShaftIntensity);
        }
        else
        {
            _sunShaftsMaterial.SetVector("_SunColor", Vector4.zero); // no backprojection !
        }

		_sunShaftsMaterial.SetTexture("_ColorBuffer", lrDepthBuffer);
		Graphics.Blit(source, destination, _sunShaftsMaterial, (ScreenBlendMode == ShaftsScreenBlendMode.Screen) ? 0 : 4); 	
		
		RenderTexture.ReleaseTemporary(lrDepthBuffer);
	}
}
