// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Ghibli_Tree"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white" {}
		_WindDirection("WindDirection", Vector) = (1,0,0,0)
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_WindSpeed("WindSpeed", Range( 0 , 2)) = 1.2
		_WindScale("WindScale", Range( 0 , 1)) = 0.2
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float3 worldPos;
			float2 uv_texcoord;
		};

		uniform float2 _WindDirection;
		uniform float _WindSpeed;
		uniform float _WindScale;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float _Cutoff = 0.5;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float2 appendResult13 = (float2(ase_worldPos.x , ase_worldPos.z));
			float2 normalizeResult19 = normalize( _WindDirection );
			float simplePerlin2D12 = snoise( ( appendResult13 + ( ( normalizeResult19 * _WindSpeed ) * _Time.y ) ) );
			float3 worldToObj32 = mul( unity_WorldToObject, float4( ( ( simplePerlin2D12 * _WindScale ) + ase_worldPos ), 1 ) ).xyz;
			v.vertex.xyz = worldToObj32;
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 color35 = IsGammaSpace() ? float4(0.2862745,0.4666667,0.2627451,1) : float4(0.06662595,0.184475,0.05612849,1);
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
201;73;724;651;-14.28838;-202.9961;1.064517;False;False
Node;AmplifyShaderEditor.Vector2Node;17;-1231.243,847.3557;Inherit;False;Property;_WindDirection;WindDirection;5;0;Create;True;0;0;0;False;0;False;1,0;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;16;-1255.756,978.0233;Inherit;False;Property;_WindSpeed;WindSpeed;7;0;Create;True;0;0;0;False;0;False;1.2;0.79;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.NormalizeNode;19;-1026.848,853.7036;Inherit;False;False;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TimeNode;22;-1015.848,1059.704;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WorldPosInputsNode;11;-898.3792,706.4408;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;20;-872.8481,907.7036;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;13;-693.3792,729.4408;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-703.8481,976.7037;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;15;-553.4567,802.343;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-418.302,1033.019;Inherit;False;Property;_WindScale;WindScale;8;0;Create;True;0;0;0;False;0;False;0.2;0.09;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;12;-396.5388,797.0408;Inherit;True;Simplex2D;False;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;24;-131.3032,921.2141;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;26;-127.083,803.2488;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;23;114.768,801.0819;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GradientNode;5;-416.4997,264.4874;Inherit;False;1;6;2;0.05882353,0.1647059,0.1764706,0.04411383;0.1176471,0.282353,0.2784314,0.2705882;0.2862745,0.4666667,0.2627451,0.682353;0.4352942,0.572549,0.4431373,0.885298;0.5568628,0.6313726,0.4196079,0.9911803;1,1,1,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.TransformPositionNode;32;359.2358,798.7571;Inherit;False;World;Object;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SamplerNode;1;-650.5956,444.123;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;-1;bd278ccb6fab06646a0277f3cd4bf7ec;bd278ccb6fab06646a0277f3cd4bf7ec;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;8;-361.3975,441.1208;Inherit;False;Annotated_BlinnPhong_Std;1;;4;365391345b582964ab83a6a52717a0c5;0;3;44;FLOAT3;0,0,0;False;24;COLOR;0,0,0,0;False;17;COLOR;0,0,0,0;False;2;FLOAT3;32;FLOAT;31
Node;AmplifyShaderEditor.TFHCGrayscale;33;-61.34089,435.3261;Inherit;False;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientSampleNode;4;-164.0395,195.6139;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;35;285.0589,311.6263;Inherit;False;Constant;_Color0;Color 0;6;0;Create;True;0;0;0;False;0;False;0.2862745,0.4666667,0.2627451,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;9;270.3079,479.4062;Inherit;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;10;271.9034,557.5715;Inherit;False;Constant;_Float1;Float 1;3;0;Create;True;0;0;0;False;0;False;1.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;605.6903,337.3944;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Ghibli_Tree;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Masked;0.5;True;True;0;False;TransparentCutout;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Absolute;0;;6;-1;-1;-1;0;False;0;0;False;-1;0;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;19;0;17;0
WireConnection;20;0;19;0
WireConnection;20;1;16;0
WireConnection;13;0;11;1
WireConnection;13;1;11;3
WireConnection;21;0;20;0
WireConnection;21;1;22;2
WireConnection;15;0;13;0
WireConnection;15;1;21;0
WireConnection;12;0;15;0
WireConnection;26;0;12;0
WireConnection;26;1;18;0
WireConnection;23;0;26;0
WireConnection;23;1;24;0
WireConnection;32;0;23;0
WireConnection;33;0;8;32
WireConnection;4;0;5;0
WireConnection;0;0;35;0
WireConnection;0;4;9;0
WireConnection;0;5;10;0
WireConnection;0;10;1;4
WireConnection;0;11;32;0
ASEEND*/
//CHKSM=FA5F72590AEAEC72830D836CFE5E8E9341FF313C