Shader "Skin_Amplify" {
	Properties {
		_Diffuse ("Diffuse", 2D) = "white" {}
		_Color_Multiply ("Color_Multiply", Vector) = (1,1,1,0)
		_Smoothness ("Smoothness", 2D) = "white" {}
		_Metallic ("Metallic", 2D) = "black" {}
		_Smoothness_Multiply ("Smoothness_Multiply", Range(1, 2)) = 1
		_Normal ("Normal", 2D) = "bump" {}
		_SSS_Mask ("SSS_Mask", 2D) = "white" {}
		_SSS_Power ("SSS_Power", Range(0, 1)) = 1
		_SSS_Sharpness ("SSS_Sharpness", Range(0, 5)) = 1
		_Value ("Value", Range(1, 2)) = 1
		_Saturation ("Saturation", Range(1, 2)) = 1
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