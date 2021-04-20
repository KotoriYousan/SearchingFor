// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Grass1_LOD1"
{
	Properties
	{
		_Buttom("Buttom", Color) = (0.1019608,0.2392157,0.2117647,1)
		_Top("Top", Color) = (0.1607843,0.3294118,0.3019608,1)
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "AlphaTest+0" }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha 
		struct Input
		{
			float4 vertexColor : COLOR;
		};

		uniform float4 _Buttom;
		uniform float4 _Top;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 lerpResult27 = lerp( _Buttom , _Top , i.vertexColor.r);
			o.Albedo = lerpResult27.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
355;73;1187;651;2368.199;748.9297;2.916261;True;False
Node;AmplifyShaderEditor.ColorNode;24;-925.148,-36.17701;Inherit;False;Property;_Top;Top;2;0;Create;True;0;0;0;False;0;False;0.1607843,0.3294118,0.3019608,1;0.5568628,0.6313726,0.4196079,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;30;-919.9818,144.6958;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;23;-930.4928,-205.2808;Inherit;False;Property;_Buttom;Buttom;1;0;Create;True;0;0;0;False;0;False;0.1019608,0.2392157,0.2117647,1;0.07058824,0.1843137,0.1921569,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GradientNode;35;-936.5081,-489.1711;Inherit;False;0;2;2;0.1019608,0.2392157,0.2117647,0.3617609;0.1645412,0.333,0.3055765,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.GradientSampleNode;19;-604.1008,-421.2896;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;27;-674.7609,-123.1815;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-440.3553,-122.483;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Grass1_LOD1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Opaque;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Absolute;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;19;0;35;0
WireConnection;27;0;23;0
WireConnection;27;1;24;0
WireConnection;27;2;30;1
WireConnection;0;0;27;0
ASEEND*/
//CHKSM=AACA311C17F992917444C12D97081F183DEEC138