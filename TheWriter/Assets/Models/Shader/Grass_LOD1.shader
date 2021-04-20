// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Grass_LOD1"
{
	Properties
	{
		_MainColor("Main Color", Color) = (0.3921569,0.3921569,0.3921569,1)
		_SpecularColor("Specular Color", Color) = (0.3921569,0.3921569,0.3921569,1)
		_Shininess("Shininess", Range( 0.01 , 1)) = 0.1
		_Buttom("Buttom", Color) = (0.2862745,0.4666667,0.2627451,1)
		_Top("Top", Color) = (0.5568628,0.6313726,0.4196079,1)
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "AlphaTest+0" }
		Cull Off
		CGPROGRAM
		#include "UnityCG.cginc"
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha 
		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
			INTERNAL_DATA
			float4 vertexColor : COLOR;
		};

		uniform float4 _SpecularColor;
		uniform float _Shininess;
		uniform float4 _MainColor;
		uniform float4 _Buttom;
		uniform float4 _Top;


		struct Gradient
		{
			int type;
			int colorsLength;
			int alphasLength;
			float4 colors[8];
			float2 alphas[8];
		};


		Gradient NewGradient(int type, int colorsLength, int alphasLength, 
		float4 colors0, float4 colors1, float4 colors2, float4 colors3, float4 colors4, float4 colors5, float4 colors6, float4 colors7,
		float2 alphas0, float2 alphas1, float2 alphas2, float2 alphas3, float2 alphas4, float2 alphas5, float2 alphas6, float2 alphas7)
		{
			Gradient g;
			g.type = type;
			g.colorsLength = colorsLength;
			g.alphasLength = alphasLength;
			g.colors[ 0 ] = colors0;
			g.colors[ 1 ] = colors1;
			g.colors[ 2 ] = colors2;
			g.colors[ 3 ] = colors3;
			g.colors[ 4 ] = colors4;
			g.colors[ 5 ] = colors5;
			g.colors[ 6 ] = colors6;
			g.colors[ 7 ] = colors7;
			g.alphas[ 0 ] = alphas0;
			g.alphas[ 1 ] = alphas1;
			g.alphas[ 2 ] = alphas2;
			g.alphas[ 3 ] = alphas3;
			g.alphas[ 4 ] = alphas4;
			g.alphas[ 5 ] = alphas5;
			g.alphas[ 6 ] = alphas6;
			g.alphas[ 7 ] = alphas7;
			return g;
		}


		float4 SampleGradient( Gradient gradient, float time )
		{
			float3 color = gradient.colors[0].rgb;
			UNITY_UNROLL
			for (int c = 1; c < 8; c++)
			{
			float colorPos = saturate((time - gradient.colors[c-1].w) / ( 0.00001 + (gradient.colors[c].w - gradient.colors[c-1].w)) * step(c, (float)gradient.colorsLength-1));
			color = lerp(color, gradient.colors[c].rgb, lerp(colorPos, step(0.01, colorPos), gradient.type));
			}
			#ifndef UNITY_COLORSPACE_GAMMA
			color = half3(GammaToLinearSpaceExact(color.r), GammaToLinearSpaceExact(color.g), GammaToLinearSpaceExact(color.b));
			#endif
			float alpha = gradient.alphas[0].x;
			UNITY_UNROLL
			for (int a = 1; a < 8; a++)
			{
			float alphaPos = saturate((time - gradient.alphas[a-1].y) / ( 0.00001 + (gradient.alphas[a].y - gradient.alphas[a-1].y)) * step(a, (float)gradient.alphasLength-1));
			alpha = lerp(alpha, gradient.alphas[a].x, lerp(alphaPos, step(0.01, alphaPos), gradient.type));
			}
			return float4(color, alpha);
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Normal = float3(0,0,1);
			Gradient gradient29 = NewGradient( 0, 2, 2, float4( 0.2862745, 0.4666667, 0.2627451, 0.2911727 ), float4( 0.5568628, 0.6313726, 0.4196079, 1 ), 0, 0, 0, 0, 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
			float4 temp_output_17_0_g4 = _SpecularColor;
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			#if defined(LIGHTMAP_ON) && UNITY_VERSION < 560 //aseld
			float3 ase_worldlightDir = 0;
			#else //aseld
			float3 ase_worldlightDir = normalize( UnityWorldSpaceLightDir( ase_worldPos ) );
			#endif //aseld
			float3 normalizeResult37_g4 = normalize( ( ase_worldViewDir + ase_worldlightDir ) );
			float3 normalizeResult10_g4 = normalize( (WorldNormalVector( i , float3(0,0,1) )) );
			float dotResult25_g4 = dot( normalizeResult37_g4 , normalizeResult10_g4 );
			#if defined(LIGHTMAP_ON) && ( UNITY_VERSION < 560 || ( defined(LIGHTMAP_SHADOW_MIXING) && !defined(SHADOWS_SHADOWMASK) && defined(SHADOWS_SCREEN) ) )//aselc
			float4 ase_lightColor = 0;
			#else //aselc
			float4 ase_lightColor = _LightColor0;
			#endif //aselc
			float3 temp_output_4_0_g4 = ( ase_lightColor.rgb * 1 );
			float dotResult5_g4 = dot( normalizeResult10_g4 , ase_worldlightDir );
			float4 temp_output_24_0_g4 = _MainColor;
			float4 lerpResult27 = lerp( _Buttom , _Top , i.vertexColor.r);
			float4 blendOpSrc33 = SampleGradient( gradient29, ( ( (temp_output_17_0_g4).rgb * (temp_output_17_0_g4).a * pow( max( dotResult25_g4 , 0.0 ) , ( _Shininess * 128.0 ) ) * temp_output_4_0_g4 ) + ( ( ( temp_output_4_0_g4 * max( dotResult5_g4 , 0.0 ) ) + float3(0,0,0) ) * (temp_output_24_0_g4).rgb ) ).x );
			float4 blendOpDest33 = lerpResult27;
			o.Albedo = ( saturate( 2.0f*blendOpDest33*blendOpSrc33 + blendOpDest33*blendOpDest33*(1.0f - 2.0f*blendOpSrc33) )).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
355;73;1187;651;1553.986;531.4573;1.9;True;False
Node;AmplifyShaderEditor.FunctionNode;16;-968.646,-356.726;Inherit;False;Annotated_BlinnPhong_Std;0;;4;365391345b582964ab83a6a52717a0c5;0;3;44;FLOAT3;0,0,0;False;24;COLOR;0,0,0,0;False;17;COLOR;0,0,0,0;False;2;FLOAT3;32;FLOAT;31
Node;AmplifyShaderEditor.ColorNode;24;-925.148,-36.17701;Inherit;False;Property;_Top;Top;6;0;Create;True;0;0;0;False;0;False;0.5568628,0.6313726,0.4196079,1;0.5568628,0.6313726,0.4196079,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;23;-930.4928,-205.2808;Inherit;False;Property;_Buttom;Buttom;5;0;Create;True;0;0;0;False;0;False;0.2862745,0.4666667,0.2627451,1;0.07058824,0.1843137,0.1921569,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GradientNode;29;-941.3192,-443.1495;Inherit;False;0;2;2;0.2862745,0.4666667,0.2627451,0.2911727;0.5568628,0.6313726,0.4196079,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.VertexColorNode;30;-919.9818,144.6958;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;27;-568.3455,-194.9046;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GradientSampleNode;19;-604.1008,-421.2896;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BlendOpsNode;33;-270.1471,-223.5675;Inherit;False;SoftLight;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.GradientNode;17;-1306.248,-535.0181;Inherit;False;0;4;2;0.4352942,0.572549,0.4431373,0;0.2862745,0.4666667,0.2627451,0.3441215;0.1176471,0.282353,0.2784314,0.9647059;0.05882353,0.1647059,0.1764706,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-24.88368,-220.221;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Grass_LOD1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Opaque;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Absolute;0;;4;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;27;0;23;0
WireConnection;27;1;24;0
WireConnection;27;2;30;1
WireConnection;19;0;29;0
WireConnection;19;1;16;32
WireConnection;33;0;19;0
WireConnection;33;1;27;0
WireConnection;0;0;33;0
ASEEND*/
//CHKSM=E9A4466644F31F1BB4C9589E3ED298BAA52A45A6