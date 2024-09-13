Shader "Vegetation" {
	Properties {
		_Cutoff ("Mask Clip Value", Float) = 0.5
		_Diffuse ("Diffuse", 2D) = "white" {}
		_MetallicRSmoothnessA ("Metallic(R)Smoothness(A)", 2D) = "black" {}
		_Normal ("Normal", 2D) = "bump" {}
		_GreenChannelMultiply ("GreenChannelMultiply", Range(0, 0.5)) = 0
		_RedChannelMultiply ("RedChannelMultiply", Range(0, 0.5)) = 0
		_WindSpeed ("WindSpeed", Range(0, 1)) = 0
		_Waves ("Waves", Range(0, 10)) = 4.774876
		_YMultiplier ("Y Multiplier", Range(0, 1)) = 0.5
		_XMultiplier ("X Multiplier", Range(0, 1)) = 0.5
		_ZMultiplier ("Z Multiplier", Range(0, 1)) = 0.5
		[Toggle] _UVSwitch ("UVSwitch", Float) = 0
		_ShimmerColor ("ShimmerColor", Vector) = (0,0,0,0)
		_Shimmer ("Shimmer", Range(0, 1)) = 1
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