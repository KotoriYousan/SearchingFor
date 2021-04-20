// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Move"
{
	Properties
	{
		_MoveSpeed("Move Speed", Float) = 50
		_ScaleandOffset("Scale and Offset", Vector) = (0.2,0,0,0)
		_CellDivisionAmount("Cell Division Amount", Float) = 2
		_BaseColor("Base Color", Color) = (0.27,0.27,0.27,1)
		_NoiseSpeed("Noise Speed", Float) = 1
		_TransitionDistanced("Transition Distanced", Float) = 174.5
		_TransitionFalloff("Transition Falloff", Float) = 88.5
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float3 worldPos;
		};

		uniform float _MoveSpeed;
		uniform float2 _ScaleandOffset;
		uniform float _TransitionDistanced;
		uniform float _TransitionFalloff;
		uniform float _CellDivisionAmount;
		uniform float _NoiseSpeed;
		uniform float4 _BaseColor;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float temp_output_3_0 = sin( ( _Time.y * _MoveSpeed ) );
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float clampResult144 = clamp( pow( ( distance( ase_worldPos , _WorldSpaceCameraPos ) / _TransitionDistanced ) , _TransitionFalloff ) , 0.0 , 1.0 );
			float CameraDistance142 = clampResult144;
			float lerpResult145 = lerp( (temp_output_3_0*_ScaleandOffset.x + _ScaleandOffset.y) , 0.0 , CameraDistance142);
			float3 temp_cast_0 = (lerpResult145).xxx;
			v.vertex.xyz += temp_cast_0;
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float3 break6_g13 = ( ase_vertex3Pos / ( _CellDivisionAmount / 100.0 ) );
			float temp_output_12_0_g13 = ( frac( ( sin( _Time.y ) * ( 532.0 + 0.0 ) ) ) * _NoiseSpeed );
			float3 appendResult13_g13 = (float3(( break6_g13.x + temp_output_12_0_g13 ) , ( break6_g13.y + temp_output_12_0_g13 ) , ( break6_g13.z + temp_output_12_0_g13 )));
			float3 temp_output_1_0_g15 = ceil( appendResult13_g13 );
			float dotResult8_g15 = dot( temp_output_1_0_g15 , float3(154,287,387) );
			float dotResult9_g15 = dot( temp_output_1_0_g15 , float3(353,517,795) );
			float dotResult10_g15 = dot( temp_output_1_0_g15 , float3(497,208,730) );
			float3 appendResult11_g15 = (float3(dotResult8_g15 , dotResult9_g15 , dotResult10_g15));
			float3 temp_cast_0 = (1.0).xxx;
			float3 temp_cast_1 = (-1.0).xxx;
			float3 temp_cast_2 = (1.0).xxx;
			float3 temp_cast_3 = (0.0).xxx;
			float3 temp_cast_4 = (1.0).xxx;
			float3 temp_output_39_0_g12 = (temp_cast_3 + (( ( frac( ( sin( appendResult11_g15 ) * ( 429.0 + 0.0 ) ) ) * 2.0 ) - temp_cast_0 ) - temp_cast_1) * (temp_cast_4 - temp_cast_3) / (temp_cast_2 - temp_cast_1));
			float3 clampResult25_g12 = clamp( pow( temp_output_39_0_g12 , float3(4,4,4) ) , float3(0,0,0) , float3(1,1,1) );
			float temp_output_3_0 = sin( ( _Time.y * _MoveSpeed ) );
			float4 BaseColor148 = _BaseColor;
			float4 color98 = IsGammaSpace() ? float4(0.3294118,0.1647059,0.3294118,1) : float4(0.08865561,0.02315336,0.08865561,1);
			float4 lerpResult91 = lerp( BaseColor148 , color98 , temp_output_3_0);
			float4 color99 = IsGammaSpace() ? float4(0.1647059,0.3294118,0.1647059,1) : float4(0.02315336,0.08865561,0.02315336,1);
			float4 lerpResult94 = lerp( BaseColor148 , color99 , abs( temp_output_3_0 ));
			float4 ifLocalVar92 = 0;
			if( temp_output_3_0 >= 0.0 )
				ifLocalVar92 = lerpResult91;
			else
				ifLocalVar92 = lerpResult94;
			float temp_output_7_0_g12 = 0.0;
			float4 lerpResult32_g12 = lerp( ( float4( ( clampResult25_g12 * float3(10,10,10) ) , 0.0 ) * ifLocalVar92 ) , BaseColor148 , temp_output_7_0_g12);
			float3 ase_worldPos = i.worldPos;
			float clampResult144 = clamp( pow( ( distance( ase_worldPos , _WorldSpaceCameraPos ) / _TransitionDistanced ) , _TransitionFalloff ) , 0.0 , 1.0 );
			float CameraDistance142 = clampResult144;
			float4 lerpResult147 = lerp( lerpResult32_g12 , BaseColor148 , CameraDistance142);
			o.Albedo = lerpResult147.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
-1186;73;780;650;923.4964;608.4173;2.643339;False;False
Node;AmplifyShaderEditor.WorldPosInputsNode;135;-345.0634,727.6598;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldSpaceCameraPos;136;-407.4684,898.8762;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TimeNode;1;-1194.157,277.7871;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;6;-1184.298,431.4446;Inherit;False;Property;_MoveSpeed;Move Speed;0;0;Create;True;0;0;0;False;0;False;50;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;138;-151.603,959.8985;Inherit;False;Property;_TransitionDistanced;Transition Distanced;9;0;Create;True;0;0;0;False;0;False;174.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DistanceOpNode;137;-140.8973,799.3134;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2;-984.8813,302.8346;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;50;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;74;-1004.552,-492.838;Inherit;False;Property;_BaseColor;Base Color;4;0;Create;True;0;0;0;False;0;False;0.27,0.27,0.27,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;148;-730.3298,-492.0244;Inherit;False;BaseColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;140;250.793,918.7787;Inherit;False;Property;_TransitionFalloff;Transition Falloff;10;0;Create;True;0;0;0;False;0;False;88.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;139;125.6733,799.3135;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;3;-854.8464,303.2612;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;141;471.7928,801.2854;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;99;-723.5179,138.5919;Inherit;False;Constant;_ShiftColorLeft;Shift Color Left;11;0;Create;True;0;0;0;False;0;False;0.1647059,0.3294118,0.1647059,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.AbsOpNode;95;-502.4212,258.1087;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;98;-716.8492,-204.1857;Inherit;False;Constant;_ShiftColorRight;Shift Color Right;11;0;Create;True;0;0;0;False;0;False;0.3294118,0.1647059,0.3294118,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;149;-764.5565,-5.391951;Inherit;False;148;BaseColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;94;-477.4066,112.5301;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;144;676.8483,802.1437;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;91;-466.8413,-109.8;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;131;-280.0331,-417.5777;Inherit;False;Property;_NoiseSpeed;Noise Speed;7;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;130;-276.5139,-313.7243;Inherit;False;Property;_DeformationStrength;Deformation Strength;5;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.IntNode;128;-268.8541,-216.215;Inherit;False;Property;_UseAlphaClipping;Use Alpha Clipping;2;0;Create;True;0;0;0;False;0;False;0;0;False;0;1;INT;0
Node;AmplifyShaderEditor.GetLocalVarNode;150;-262.8044,-803.5017;Inherit;False;148;BaseColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;132;-281.1082,-505.8887;Inherit;False;Property;_CellDivisionAmount;Cell Division Amount;3;0;Create;True;0;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ConditionalIfNode;92;-257.0057,-71.59499;Inherit;False;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;7;-482.1738,382.033;Inherit;False;Property;_ScaleandOffset;Scale and Offset;1;0;Create;True;0;0;0;False;0;False;0.2,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RegisterLocalVarNode;142;849.3565,794.7622;Inherit;False;CameraDistance;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;152;162.9944,26.90045;Inherit;False;142;CameraDistance;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;146;-94.85132,448.574;Inherit;False;142;CameraDistance;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;151;186.2435,-80.40366;Inherit;False;148;BaseColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;134;55.4644,-379.8183;Inherit;True;M_Glitch;-1;;12;f349c3782ae8dda428b04df1fd01e26c;0;8;1;COLOR;1,1,1,0;False;2;COLOR;1,1,1,0;False;3;FLOAT;0.04;False;4;FLOAT;5;False;5;FLOAT;1;False;6;FLOAT;0;False;7;FLOAT;0;False;8;INT;0;False;3;FLOAT3;37;FLOAT;21;COLOR;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;4;-252.6207,296.4994;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.2;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;78;1262.63,-545.7079;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;1;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;81;844.3149,-454.993;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;75;638.1583,-390.2291;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;147;452.4941,-99.05872;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;82;663.1348,-508.8072;Inherit;False;Property;_ColorOffset;Color Offset;6;0;Create;True;0;0;0;False;0;False;0.6;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;87;1107.508,-534.4259;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;145;92.46011,299.2033;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;88;1109.335,-406.5562;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;129;-298.0407,-711.4973;Inherit;False;Property;_GlitchEmissionColor;Glitch Emission Color;8;0;Create;True;0;0;0;False;0;False;1,1,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;702.3162,-98.72157;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Move;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;137;0;135;0
WireConnection;137;1;136;0
WireConnection;2;0;1;2
WireConnection;2;1;6;0
WireConnection;148;0;74;0
WireConnection;139;0;137;0
WireConnection;139;1;138;0
WireConnection;3;0;2;0
WireConnection;141;0;139;0
WireConnection;141;1;140;0
WireConnection;95;0;3;0
WireConnection;94;0;149;0
WireConnection;94;1;99;0
WireConnection;94;2;95;0
WireConnection;144;0;141;0
WireConnection;91;0;149;0
WireConnection;91;1;98;0
WireConnection;91;2;3;0
WireConnection;92;0;3;0
WireConnection;92;2;91;0
WireConnection;92;3;91;0
WireConnection;92;4;94;0
WireConnection;142;0;144;0
WireConnection;134;1;150;0
WireConnection;134;2;92;0
WireConnection;134;3;132;0
WireConnection;134;4;131;0
WireConnection;134;5;130;0
WireConnection;134;8;128;0
WireConnection;4;0;3;0
WireConnection;4;1;7;1
WireConnection;4;2;7;2
WireConnection;78;0;87;0
WireConnection;78;1;88;0
WireConnection;81;0;82;0
WireConnection;81;1;75;0
WireConnection;147;0;134;0
WireConnection;147;1;151;0
WireConnection;147;2;152;0
WireConnection;87;1;81;0
WireConnection;145;0;4;0
WireConnection;145;2;146;0
WireConnection;88;1;81;0
WireConnection;0;0;147;0
WireConnection;0;11;145;0
ASEEND*/
//CHKSM=6E3945B42C1905F627CFC5A7C3099A8520608A8E