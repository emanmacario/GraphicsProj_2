Shader "Unlit/PortalShader"
{
	Properties
	{
		_Base ("Highlight Colour", Color) = (1, 1, 1, 1)
		_Highlight ("Highlight Colour", Color) = (0, 0, 0, 1)
		_Waves ("Number of waves", int) = 10
		_Speed ("Wave speed", float) = 1
		_Narrowness ("Wave narrowness", int) = 4
		
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

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
			};

			uniform float4 _Base, _Highlight;
			uniform int _Waves, _Narrowness;
			uniform float _Speed;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float radius = length(i.uv - float2(0.5,0.5))*2;
				float result = pow(sin(radius*_Waves + _Time.y*_Waves*_Speed),4);
				fixed4 col = lerp(_Base, _Highlight, result);
				return col;
			}
			ENDCG
		}
	}
}
