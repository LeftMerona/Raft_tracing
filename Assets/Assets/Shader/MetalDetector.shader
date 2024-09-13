Shader "MetalDetector" {
	Properties {
		_Diffuse ("Diffuse", 2D) = "white" {}
		_MetallicRMaskGSmoothnessA ("Metallic(R) Mask(G) Smoothness(A)", 2D) = "black" {}
		_Normal ("Normal", 2D) = "bump" {}
		_Emission ("Emission", 2D) = "black" {}
		_Lights ("Lights", Range(0, 1)) = 0
		_EmissionIntensity ("EmissionIntensity", Float) = 2
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