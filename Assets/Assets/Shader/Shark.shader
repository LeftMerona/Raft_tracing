Shader "Shark" {
	Properties {
		_Cutoff ("Mask Clip Value", Float) = 0.5
		_Normal ("Normal", 2D) = "white" {}
		_NormalDamaged ("NormalDamaged", 2D) = "white" {}
		_DiffuseDamaged ("DiffuseDamaged", 2D) = "white" {}
		_DamageMask ("DamageMask", 2D) = "white" {}
		_Diffuse ("Diffuse", 2D) = "white" {}
		_SharkHP ("SharkHP", Range(0, 1)) = 5
		_Dither ("Dither", Float) = 1
		_Dissolve ("Dissolve", Range(0, 1)) = 1
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