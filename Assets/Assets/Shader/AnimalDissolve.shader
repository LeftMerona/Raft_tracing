Shader "AnimalDissolve" {
	Properties {
		_Diffuse ("Diffuse", 2D) = "white" {}
		_Color ("Color", Vector) = (1,1,1,0)
		_MetallicRSmoothnesA ("Metallic(R) Smoothnes(A)", 2D) = "black" {}
		_Smoothness_Multiplyer ("Smoothness_Multiplyer", Range(0, 1)) = 1
		_Normal ("Normal", 2D) = "bump" {}
		_Emission ("Emission", 2D) = "black" {}
		_EmissionIntensity ("EmissionIntensity", Float) = 1
		_Diffuse_Damaged ("Diffuse_Damaged", 2D) = "white" {}
		_MetallicRSmoothnesA_Damaged ("Metallic(R) Smoothnes(A)_Damaged", 2D) = "black" {}
		_Normal_Damaged ("Normal_Damaged", 2D) = "bump" {}
		_Emission_Damaged ("Emission_Damaged", 2D) = "black" {}
		_Cutoff ("Mask Clip Value", Float) = 0.5
		_Dither ("Dither", Float) = 1
		_Dissolve ("Dissolve", Range(0, 1)) = 1
		_Damaged_HP ("Damaged_HP", Range(0, 1)) = 5
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ASEMaterialInspector"
}