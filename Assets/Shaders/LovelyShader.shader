﻿Shader "Unlit/LovelyShader" {	
	Properties {
		_Color("Color", Color) = (1, 1, 1, 1)
		_MainTex("Albedo (RGB)", 2D) = "white"
		_amb ("Ambient Light", Float) = 0
		_t1("Threshold 1", Float) = 0
		_l1("Level 1", Float) = 0
		_t2("Threshold 2", Float) = 0.3
		_l2("Level 2", float) = 0.3
		_t3("Threshold 3", Float) = 0.5
		_l3("Level 3", float) = 0.5
	}
	SubShader {
		LOD 200
		Stencil {
		  Ref 1
		  Comp NotEqual
		}
		CGPROGRAM
		#pragma surface surf CelShadingForward fullforwardshadows
		#pragma target 3.0
		//based on code from http://xdavidleon.tumblr.com/post/122950440695/next-gen-cel-shading-in-unity-5
		
		#include "UnityCG.cginc"
		
		uniform float _t1,_t2,_t3,_l1,_l2,_l3, _amb;


		half4 LightingCelShadingForward(SurfaceOutput s, half3 lightDir, half atten) {
			half NdotL = dot(s.Normal, lightDir);
			
			if (NdotL <= _t1) NdotL = _l1;
			else if (NdotL <= _t2) NdotL = _l2;
			else if (NdotL <= _t3) NdotL = _l3;
			else NdotL = 1;
			
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * ((NdotL * atten * 2) + _amb);
			c.a = s.Alpha;
			return c;
		}

		sampler2D _MainTex;
		fixed4 _Color;

		struct Input {
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "VertexLit"
}