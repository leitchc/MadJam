Shader "Custom/Test 2" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_QOffset ("Offset", Vector) = (0,0,0,0)
		_Resolution ("Resolution", Vector) = (0,0,0,0)
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
			float4 _Resolution;
			float _Speed;
			
			struct v2f {
			    float4 pos : SV_POSITION;
			    //float4 uv : TEXCOORD0;
			    float2 uv : TEXCOORD0;
			    float2 pos2 : TEXCOORD1;
			};

			v2f vert (appdata_base v)
			{
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
			    o.pos2 = o.pos;
			    return o;
			}

			half4 frag (v2f i) : COLOR
			{

				float2 p = -1.0 + 2.0 * (i.pos2.xy);

				float a = atan(p.y,p.x);
				float r = sqrt(dot(p,p));

				i.uv.x = 0.1/r;
				i.uv.y = a/(3.1416);

			    half4 col = tex2D(_MainTex, i.uv * (_Time.xz));
			    return col;
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
