Shader "Rope_Amplify" {
	Properties {
		_Diffuse ("Diffuse", 2D) = "white" {}
		_Color0 ("Color 0", Vector) = (0,0,0,0)
		_Smoothness ("Smoothness", Range(0, 1)) = 0
		_NormalMap ("Normal Map", 2D) = "white" {}
		_Hue ("Hue", Range(-0.5, 0.5)) = 0
		_Saturation ("Saturation", Range(-0.5, 0.5)) = 0
		_Value ("Value", Range(-0.5, 0.5)) = 0
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