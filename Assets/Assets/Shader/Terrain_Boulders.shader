Shader "Terrain_Boulders" {
	Properties {
		_MainNormal ("MainNormal", 2D) = "bump" {}
		_RockDiffuse ("RockDiffuse", 2D) = "white" {}
		_ColorMultiply ("ColorMultiply", Vector) = (1,1,1,0)
		_RockNormal ("RockNormal", 2D) = "bump" {}
		_RockNormalStrength ("RockNormalStrength", Range(0, 1)) = 1
		_RockMetallicRSmoothnessA ("RockMetallic(R) Smoothness(A)", 2D) = "white" {}
		_RockTile ("RockTile", Range(0.1, 10)) = 1
		_EdgeMask ("EdgeMask", 2D) = "black" {}
		_EdgeColor ("EdgeColor", Vector) = (0,0,0,0)
		_EdgeStrength ("EdgeStrength", Range(0, 1)) = 1
		_Smoothness_Multiplier ("Smoothness_Multiplier", Range(0, 1)) = 1
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