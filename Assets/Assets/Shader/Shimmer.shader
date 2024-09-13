Shader "Shimmer" {
	Properties {
		_Cutoff ("Mask Clip Value", Float) = 0.5
		_Diffuse ("Diffuse", 2D) = "white" {}
		_MetallicRSmoothnessA ("Metallic(R)Smoothness(A)", 2D) = "white" {}
		_Emission ("Emission", 2D) = "black" {}
		_Normal ("Normal", 2D) = "bump" {}
		_ShimmerColor ("ShimmerColor", Vector) = (0,0,0,0)
		_Shimmer ("Shimmer", Range(0, 1)) = 1
		_Shimmer_Fresnel_Amount ("Shimmer_Fresnel_Amount", Range(0, 1)) = 0
		_Shimmer_Distance_Offset ("Shimmer_Distance_Offset", Float) = 6
		_EmissionIntensity ("EmissionIntensity", Float) = 1
		_EmissionSwitch ("EmissionSwitch", Range(0, 1)) = 1
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