Shader "Unlit/LovelyShader" {	
	Properties {
		_Color("Color", Color) = (1, 1, 1, 1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_invPla("Invisible player position", Vector) = (0,0,100)
		_invRad("Radius of invisibility", Float) = -1
	}
	SubShader {
		Tags {
			 "Queue"="Transparent" 
			 "RenderType"="Transparent"
		}
		LOD 200

		CGPROGRAM
		#pragma surface surf CelShadingForward fullforwardshadows alpha
		#pragma target 3.0
		//based on code from http://xdavidleon.tumblr.com/post/122950440695/next-gen-cel-shading-in-unity-5
		
		#include "UnityCG.cginc"


		half4 LightingCelShadingForward(SurfaceOutput s, half3 lightDir, half atten) {
			half NdotL = dot(s.Normal, lightDir);
			if (NdotL <= 0.0) NdotL = 0;
			else NdotL = 1;
			
			if (atten <= 0.2) atten = 0;
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten * 2);
			c.a = s.Alpha;
			return c;
		}

		sampler2D _MainTex;
		fixed4 _Color;
		fixed3 _invPla;
		float _invRad;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			
			if (length(_invPla - IN.worldPos) < _invRad) o.Alpha = 0;
			else o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "VertexLit"
	FallBack "Diffuse"
}