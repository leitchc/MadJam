/*
	Code taken from http://answers.unity3d.com/questions/288835/how-to-make-plane-look-curved.html
*/
Shader "Custom/Curved" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_QOffset ("Offset", Vector) = (0,0,0,0)
		_Dist ("Distance", Float) = 100.0
		_Speed ("Speed", Float) = 0.25
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

            sampler2D _MainTex;
            uniform float4 _MainTex_ST;
            fixed4 _Color;
			float4 _QOffset;
			float _Dist;
			float _Speed;
			
			struct v2f {
			    float4 pos : SV_POSITION;
			    //float4 uv : TEXCOORD0;
			    float2 uv : TEXCOORD0;
			};

			v2f vert (appdata_base v)
			{
			    v2f o;
			    float4 vPos = mul (UNITY_MATRIX_MV, v.vertex);
			    float zOff = vPos.z/_Dist;
			    vPos += _QOffset*zOff*zOff;
			    o.pos = mul (UNITY_MATRIX_P, vPos);
			    //o.uv = v.texcoord;
			    o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
			    return o;
			}

			half4 frag (v2f i) : COLOR
			{
			    half4 col = tex2D(_MainTex, i.uv + (_Time.xz * _Speed)) * _Color;
			    return col;
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
