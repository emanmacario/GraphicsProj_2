Shader "Unlit/PortalShader"
{
	Properties
	{
		_Base ("Base Colour", Color) = (1, 1, 1, 1)
		_Highlight ("Highlight Colour", Color) = (0, 0, 0, 1)
		_Waves ("Number of waves", int) = 10
		_Speed ("Wave speed", float) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
		Stencil {
		  Ref 1
		  Comp NotEqual
		}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float phase : TEXCOORD1;
			};

			uniform float4 _Base, _Highlight;
			uniform int _Waves, _Narrowness;
			uniform float _Speed;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.phase = _Time.y*_Waves*_Speed;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float radius = length(i.uv - float2(0.5,0.5))*2;
				float result = pow(sin(radius*_Waves + i.phase),4);
				return lerp(_Base, _Highlight, result);
			}
			ENDCG
		}
	}
}
