//UNITY_SHADER_NO_UPGRADE

Shader "Unlit/Invisible"
{
	Properties {
		_InvisiColour ("Color", Color) = (0, 0, 0, 0.05)
	}
	SubShader {
		Tags { "Queue" = "Transparent+100" }
		Pass {			
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
 
			uniform float4 _InvisiColour;

			struct vertIn
			{
				float4 vertex : POSITION;
				float4 normal : NORMAL;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float3 normal : TEXCOORD0;
				float3 viewDir : TEXCOORD1;
			};

			
			vertOut vert(vertIn v)
			{
				vertOut o;
				
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);				
				o.viewDir = normalize(_WorldSpaceCameraPos - mul(unity_ObjectToWorld, v.vertex).xyz);				
				o.normal = normalize(mul(transpose((float3x3)unity_WorldToObject), v.normal.xyz));

				return o;
			}
			
			
			fixed4 frag(vertOut v) : SV_Target
			{
				float3 normalDirection = normalize(v.normal);
				float3 viewDirection = normalize(v.viewDir);
 
				float newOpacity = min(1.0, _InvisiColour.a 
					/ pow(abs(dot(viewDirection, normalDirection)), 1.5));
				return float4(_InvisiColour.rgb, newOpacity);
			}

			ENDCG

		}
		
		Pass
        {
			//TODO: Cast shadows in accordance to the way the thing is rendered (not sure it's possible)
            Tags {"LightMode"="ShadowCaster"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_shadowcaster
            #include "UnityCG.cginc"

            struct v2f { 
                V2F_SHADOW_CASTER;
            };

            v2f vert(appdata_base v)
            {
                v2f o;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
	}
}
