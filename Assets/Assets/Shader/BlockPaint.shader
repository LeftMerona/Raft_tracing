Shader " BlockPaint" {
	Properties {
		_Cutoff ("Mask Clip Value", Float) = 0.5
		_Diffuse ("Diffuse", 2D) = "white" {}
		_MetallicRPaintMaskGSmoothnessA ("Metallic(R) PaintMask(G) Smoothness(A)", 2D) = "black" {}
		_Normal ("Normal", 2D) = "bump" {}
		_Emission ("Emission", 2D) = "black" {}
		_EmissionMultiplier ("EmissionMultiplier", Float) = 1
		_EmissionSwitch ("EmissionSwitch", Range(0, 1)) = 1
		_Side1_Base ("Side1_Base", Vector) = (1,1,1,0)
		_Side1_Pattern ("Side1_Pattern", Vector) = (1,1,1,0)
		_Side2_Base ("Side2_Base", Vector) = (0,0,0,0)
		_Side2_Pattern ("Side2_Pattern", Vector) = (0,0,0,0)
		_PaintSide ("PaintSide", Range(0, 3)) = 0
		_DecoPaintSelect ("DecoPaintSelect", Range(0, 3)) = 0
		_PatternArray ("PatternArray", 2DArray) = "black" {}
		_Pattern_Index1 ("Pattern_Index1", Range(0, 7)) = 0
		_Pattern_Index2 ("Pattern_Index2", Range(0, 7)) = 0
		_TriplanarFalloff ("TriplanarFalloff", Float) = 1
		_Pattern1_Masked ("Pattern1_Masked", Range(0, 1)) = 1
		_Pattern2_Masked ("Pattern2_Masked", Range(0, 1)) = 1
		_Pattern1_MaskFlip ("Pattern1_MaskFlip", Range(0, 1)) = 1
		_Pattern2_MaskFlip ("Pattern2_MaskFlip", Range(0, 1)) = 1
		_GreenChannelMultiply ("GreenChannelMultiply", Range(0, 0.5)) = 0
		_RedChannelMultiply ("RedChannelMultiply", Range(0, 0.5)) = 0
		_WindSpeed ("WindSpeed", Range(0, 1)) = 0
		_Waves ("Waves", Range(0, 10)) = 4.774876
		_YMultiplier ("Y Multiplier", Range(0, 1)) = 0.5
		_XMultiplier ("X Multiplier", Range(0, 1)) = 0.5
		_ZMultiplier ("Z Multiplier", Range(0, 1)) = 0.5
		[Toggle] _UVSwitch ("UVSwitch", Float) = 1
		[Toggle] _UV_VertexPos_Switch ("UV_VertexPos_Switch", Float) = 0
		_BuildingEmission ("BuildingEmission", Vector) = (0,0,0,0)
		_Destroy_Overlay ("Destroy_Overlay", Range(0, 1)) = 0
		_PaintMaskOverride ("PaintMaskOverride", Range(0, 1)) = 0
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