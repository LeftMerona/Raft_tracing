Shader "DrinkingGlass" {
	Properties {
		_Diffuse ("Diffuse", 2D) = "white" {}
		_MetallicSmoothness ("Metallic Smoothness", 2D) = "black" {}
		_TextureSample2 ("Texture Sample 2", 2D) = "bump" {}
		_Fresnel_Bias ("Fresnel_Bias", Float) = 0
		_FresnelColor ("FresnelColor", Vector) = (0,0,0,0)
		_Fresnel_Scale ("Fresnel_Scale", Float) = 1
		_Fresnel_Power ("Fresnel_Power", Float) = 5
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ASEMaterialInspector"
}