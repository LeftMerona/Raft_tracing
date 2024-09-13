Shader "Shader Forge/ParticleShader" {
	Properties {
		_MainTex ("MainTex", 2D) = "white" {}
		_TintColor ("Color", Vector) = (1,1,1,1)
		_Softness ("Softness", Range(0, 1)) = 0
		_LightOpacityPower ("LightOpacityPower", Range(1, 10)) = 1
		_OpacityClamp ("OpacityClamp", Range(0, 0.2)) = 0
		_OpacityMultiply ("OpacityMultiply", Range(1, 10)) = 1
		_Fresnel_Exp ("Fresnel_Exp", Float) = 2
		[MaterialToggle] _Fresnel ("Fresnel", Float) = 0
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	//CustomEditor "ShaderForgeMaterialInspector"
}