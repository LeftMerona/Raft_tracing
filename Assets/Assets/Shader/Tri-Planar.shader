Shader "Tri-Planar" {
	Properties {
		_Diffuse ("Diffuse", 2D) = "white" {}
		_MetallicSmoothness ("Metallic/Smoothness", 2D) = "black" {}
		_Metallic ("Metallic", Range(0, 1)) = 0
		_Smoothness_Add ("Smoothness_Add", Range(0, 1)) = 0
		_Normal ("Normal", 2D) = "bump" {}
		_Tiling ("Tiling", Float) = 1
		_TriplanarFalloff ("Triplanar Falloff", Float) = 1
		_NormalBase ("NormalBase", 2D) = "bump" {}
		_SquareGradient ("SquareGradient", Range(0, 3)) = 0
		_SquareGradient_Color ("SquareGradient_Color", Vector) = (1,1,1,0)
		_SquareGradient_Depth ("SquareGradient_Depth", Range(1, 10)) = 3
		_TintSwitch ("TintSwitch", Range(0, 1)) = 0
		_TintR ("Tint(R)", Vector) = (0,0,0,0)
		_NormalStrength ("NormalStrength", Float) = 1
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