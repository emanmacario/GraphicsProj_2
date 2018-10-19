Shader "Unlit/HaloShader"
{
	SubShader
	{
		Tags { "Queue" = "Geometry-1" }  
		ColorMask 0
		ZWrite Off 
		LOD 100
		
		Stencil	{
			Ref 1
			Comp Always
			Pass Replace
		}
		Pass {}
	}
}
