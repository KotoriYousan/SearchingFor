// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Ghibli_Tree_LOD1"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white" {}
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 color35 = IsGammaSpace() ? float4(0.2862745,0.4666667,0.2627451,1) : float4(0.06662594,0.184475,0.05612849,1);
			o.Albedo = color35.rgb;
			o.Smoothness = 0.0;
			o.Occlusion = 1.5;
			o.Alpha = 1;
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			clip( tex2D( _MainTex, uv_MainTex ).a - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
355;73;1187;651;2258.569;-26.49566;2.737464;True;False
Node;AmplifyShaderEditor.GradientNode;5;-416.4997,264.4874;Inherit;False;1;6;2;0.05882353,0.1647059,0.1764706,0.04411383;0.1176471,0.282353,0.2784314,0.2705882;0.2862745,0.4666667,0.2627451,0.682353;0.4352942,0.572549,0.4431373,0.885298;0.5568628,0.6313726,0.4196079,0.9911803;1,1,1,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.SamplerNode;1;-650.5956,444.123;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;-1;bd278ccb6fab06646a0277f3cd4bf7ec;bd278ccb6fab06646a0277f3cd4bf7ec;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;8;-361.3975,441.1208;Inherit;False;Annotated_BlinnPhong_Std;1;;4;365391345b582964ab83a6a52717a0c5;0;3;44;FLOAT3;0,0,0;False;24;COLOR;0,0,0,0;False;17;COLOR;0,0,0,0;False;2;FLOAT3;32;FLOAT;31
Node;AmplifyShaderEditor.TFHCGrayscale;33;-61.34089,435.3261;Inherit;False;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientSampleNode;4;-164.0395,195.6139;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;35;285.0589,311.6263;Inherit;False;Constant;_Color0;Color 0;6;0;Create;True;0;0;0;False;0;False;0.2862745,0.4666667,0.2627451,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;9;270.3079,479.4062;Inherit;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;10;271.9034,557.5715;Inherit;False;Constant;_Float1;Float 1;3;0;Create;True;0;0;0;False;0;False;1.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;605.6903,337.3944;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Ghibli_Tree_LOD1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Masked;0.5;True;True;0;False;TransparentCutout;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Absolute;0;;5;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;33;0;8;32
WireConnection;4;0;5;0
WireConnection;0;0;35;0
WireConnection;0;4;9;0
WireConnection;0;5;10;0
WireConnection;0;10;1;4
ASEEND*/
//CHKSM=B52BE1475938233B840F20C723CA72BBB0E30573