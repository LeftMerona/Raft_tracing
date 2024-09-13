Shader "BuildingShader" {
	Properties {
		[HideInInspector] __dirty ("", Float) = 1
		_Color2 ("Color2", Vector) = (0,0,0,0)
		_Color1 ("Color1", Vector) = (0,0,0,0)
		_Emission ("Emission", Range(0, 1)) = 0
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