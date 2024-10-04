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
		Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }
		LOD 200
		HLSLPROGRAM
      #pragma vertex vert
      #pragma fragment frag
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv: TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS  : SV_POSITION;
                float2 uv: TEXCOORD0;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)
            float4 _Color;
            float4 _BaseMap_ST;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;

                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);

                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float4 texel = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv);
                return texel * _Color;
            }
		ENDHLSL        
        }
	}
}