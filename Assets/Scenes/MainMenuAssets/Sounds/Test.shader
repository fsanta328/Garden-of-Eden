Shader "GPG220/Test"
{
Properties{
   _Color("main color",color) = (1,1,1,1)
   _MainTex ("main texture", 2D) = "white" {}
}
	SubShader
	{ 
		Tags { "RenderType"="Opaque" "LightMode" ="ForwardBase"}


		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "UnityLightingCommon.cginc"
			
			float4 _Color;
			sampler2D _MainTex;


			struct v2f
			{
				float4 screenPos : SV_POSITION;
				float2 uv:TEXCOORD0;
				float4 diff: COLOR;
			};
			
			v2f vert (appdata_base v)
			{
				v2f o;
				o.screenPos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord; 
				half3 worldNormal = UnityObjectToWoldNormal(v.normal);
				// dot = sin (angle in between) * Length of VI * Length of V2;
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz);
				o.diff = nl *_LightColor0;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target 
			{
	
				fixed4 col =tex2D(_MainTex,i.uv)*_Color;			
				return col;
			}
			ENDCG
		}
	}
}
