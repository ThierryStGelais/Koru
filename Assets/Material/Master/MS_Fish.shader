// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-3878-OUT,spec-4486-OUT,gloss-6178-OUT,normal-457-OUT,emission-7682-OUT,olwid-8080-OUT,olcol-8469-OUT;n:type:ShaderForge.SFN_Tex2d,id:7736,x:29816,y:31668,ptovrint:True,ptlb:Diffuse,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:dd9f7bb5345a6e94e9d7a7fe5d41c644,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:31902,y:34041,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f19bc11dd463d2046a18ee489a4a30d5,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:31712,y:32620,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:31725,y:32985,ptovrint:False,ptlb:Roughness,ptin:_Roughness,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:9837,x:30108,y:31668,varname:node_9837,prsc:2|A-7736-RGB,B-327-RGB;n:type:ShaderForge.SFN_Color,id:327,x:29816,y:31862,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:3245,x:30327,y:31668,varname:node_3245,prsc:2|A-9837-OUT,B-1101-OUT;n:type:ShaderForge.SFN_Clamp01,id:1994,x:31333,y:31685,varname:node_1994,prsc:2|IN-4343-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:4486,x:32133,y:32620,ptovrint:False,ptlb:Use Metalic Texture,ptin:_UseMetalicTexture,varname:node_4486,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-358-OUT,B-6672-R;n:type:ShaderForge.SFN_Tex2d,id:6672,x:31780,y:32726,ptovrint:False,ptlb:Metalic Texture,ptin:_MetalicTexture,varname:node_6672,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_SwitchProperty,id:6178,x:32124,y:32986,ptovrint:False,ptlb:Use Roughness Texture,ptin:_UseRoughnessTexture,varname:node_6178,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-1813-OUT,B-8714-OUT;n:type:ShaderForge.SFN_Tex2d,id:9474,x:31234,y:33081,ptovrint:False,ptlb:Roughness Texture,ptin:_RoughnessTexture,varname:node_9474,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:44,x:31234,y:33291,ptovrint:False,ptlb:Roughness Mutiplier,ptin:_RoughnessMutiplier,varname:node_44,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:9918,x:31491,y:33156,varname:node_9918,prsc:2|A-9474-R,B-44-OUT;n:type:ShaderForge.SFN_Clamp01,id:8714,x:31894,y:33155,varname:node_8714,prsc:2|IN-5011-OUT;n:type:ShaderForge.SFN_Vector3,id:9311,x:31902,y:33926,varname:node_9311,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Lerp,id:457,x:32151,y:34022,varname:node_457,prsc:2|A-9311-OUT,B-5964-RGB,T-1838-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1838,x:31902,y:34250,ptovrint:False,ptlb:Normal Map Multiplier,ptin:_NormalMapMultiplier,varname:node_1838,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector3,id:8537,x:31898,y:34510,varname:node_8537,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_SwitchProperty,id:7682,x:32132,y:34510,ptovrint:False,ptlb:Use Emmisive Texture,ptin:_UseEmmisiveTexture,varname:node_7682,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-8537-OUT,B-6218-OUT;n:type:ShaderForge.SFN_Tex2d,id:7177,x:31748,y:34649,ptovrint:False,ptlb:Emmissive Texture,ptin:_EmmissiveTexture,varname:node_7177,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:4543,x:31751,y:34871,ptovrint:False,ptlb:Emmissive Multiplier,ptin:_EmmissiveMultiplier,varname:node_4543,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:6218,x:31930,y:34649,varname:node_6218,prsc:2|A-7177-RGB,B-4543-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1101,x:30120,y:31857,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_1101,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:5011,x:31694,y:33155,varname:node_5011,prsc:2|A-9918-OUT,B-391-OUT;n:type:ShaderForge.SFN_ValueProperty,id:391,x:31442,y:33380,ptovrint:False,ptlb:Roughness Add,ptin:_RoughnessAdd,varname:node_391,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Fresnel,id:4326,x:30643,y:31833,varname:node_4326,prsc:2|EXP-4259-OUT;n:type:ShaderForge.SFN_Lerp,id:4343,x:31047,y:31682,varname:node_4343,prsc:2|A-3245-OUT,B-2274-RGB,T-7446-OUT;n:type:ShaderForge.SFN_Multiply,id:7446,x:30827,y:31902,varname:node_7446,prsc:2|A-4326-OUT,B-299-OUT;n:type:ShaderForge.SFN_Vector1,id:4259,x:30473,y:31833,varname:node_4259,prsc:2,v1:3;n:type:ShaderForge.SFN_Vector1,id:299,x:30643,y:31998,varname:node_299,prsc:2,v1:20;n:type:ShaderForge.SFN_Color,id:2274,x:30827,y:31748,ptovrint:False,ptlb:Rim Color,ptin:_RimColor,varname:node_2274,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5361024,c2:0.8602941,c3:0.164468,c4:1;n:type:ShaderForge.SFN_Vector1,id:8080,x:32333,y:33020,varname:node_8080,prsc:2,v1:0.05;n:type:ShaderForge.SFN_SwitchProperty,id:8469,x:32314,y:33463,ptovrint:False,ptlb:Two Target Line,ptin:_TwoTargetLine,varname:node_8469,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-2274-RGB,B-9246-OUT;n:type:ShaderForge.SFN_TexCoord,id:1694,x:31487,y:33499,varname:node_1694,prsc:2,uv:0;n:type:ShaderForge.SFN_If,id:7468,x:31693,y:33540,varname:node_7468,prsc:2|A-1694-U,B-2383-OUT,GT-2886-OUT,EQ-2886-OUT,LT-1169-OUT;n:type:ShaderForge.SFN_Vector1,id:2383,x:31487,y:33660,varname:node_2383,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:2886,x:31487,y:33733,varname:node_2886,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1169,x:31487,y:33807,varname:node_1169,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:9246,x:31899,y:33499,varname:node_9246,prsc:2|A-2274-RGB,B-3133-RGB,T-7468-OUT;n:type:ShaderForge.SFN_Color,id:3133,x:30827,y:32071,ptovrint:False,ptlb:Rim Color 2,ptin:_RimColor2,varname:node_3133,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7882354,c2:0.1254902,c3:0.7490196,c4:1;n:type:ShaderForge.SFN_TexCoord,id:486,x:30633,y:32248,varname:node_486,prsc:2,uv:0;n:type:ShaderForge.SFN_If,id:4479,x:30839,y:32289,varname:node_4479,prsc:2|A-486-U,B-5252-OUT,GT-3437-OUT,EQ-3437-OUT,LT-2869-OUT;n:type:ShaderForge.SFN_Vector1,id:5252,x:30633,y:32409,varname:node_5252,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:3437,x:30633,y:32482,varname:node_3437,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2869,x:30633,y:32556,varname:node_2869,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:4264,x:31045,y:32248,varname:node_4264,prsc:2|A-2274-RGB,B-3133-RGB,T-4479-OUT;n:type:ShaderForge.SFN_Clamp01,id:4296,x:31523,y:32251,varname:node_4296,prsc:2|IN-4260-OUT;n:type:ShaderForge.SFN_Lerp,id:4260,x:31237,y:32248,varname:node_4260,prsc:2|A-3245-OUT,B-4264-OUT,T-7446-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:3878,x:31868,y:31959,ptovrint:False,ptlb:Two Target Color,ptin:_TwoTargetColor,varname:node_3878,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-1994-OUT,B-4296-OUT;proporder:7736-327-1101-5964-1838-1813-6178-9474-44-391-4486-6672-358-7682-7177-4543-2274-8469-3878-3133;pass:END;sub:END;*/

Shader "Shader Forge/MS_Fish" {
    Properties {
        _MainTex ("Diffuse", 2D) = "white" {}
        _Tint ("Tint", Color) = (1,1,1,1)
        _Brightness ("Brightness", Float ) = 0
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _NormalMapMultiplier ("Normal Map Multiplier", Float ) = 1
        _Roughness ("Roughness", Range(0, 1)) = 1
        [MaterialToggle] _UseRoughnessTexture ("Use Roughness Texture", Float ) = 0
        _RoughnessTexture ("Roughness Texture", 2D) = "white" {}
        _RoughnessMutiplier ("Roughness Mutiplier", Float ) = 1
        _RoughnessAdd ("Roughness Add", Float ) = 0
        [MaterialToggle] _UseMetalicTexture ("Use Metalic Texture", Float ) = 0
        _MetalicTexture ("Metalic Texture", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        [MaterialToggle] _UseEmmisiveTexture ("Use Emmisive Texture", Float ) = 0
        _EmmissiveTexture ("Emmissive Texture", 2D) = "white" {}
        _EmmissiveMultiplier ("Emmissive Multiplier", Float ) = 1
        _RimColor ("Rim Color", Color) = (0.5361024,0.8602941,0.164468,1)
        [MaterialToggle] _TwoTargetLine ("Two Target Line", Float ) = 0.7882354
        [MaterialToggle] _TwoTargetColor ("Two Target Color", Float ) = 0.7882354
        _RimColor2 ("Rim Color 2", Color) = (0.7882354,0.1254902,0.7490196,1)
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
		Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
		Pass
             {
                 Blend SrcAlpha OneMinusSrcAlpha
                 ZWrite Off
                 ZTest Greater
                 Lighting Off
                 //SetTexture [_SeeTroughTex] {combine texture}
				 Color [_RimColor]
             }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _RimColor;
            uniform fixed _TwoTargetLine;
            uniform float4 _RimColor2;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*0.05,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_7468_if_leA = step(i.uv0.r,0.5);
                float node_7468_if_leB = step(0.5,i.uv0.r);
                float node_2886 = 0.0;
                return fixed4(lerp( _RimColor.rgb, lerp(_RimColor.rgb,_RimColor2.rgb,lerp((node_7468_if_leA*1.0)+(node_7468_if_leB*node_2886),node_2886,node_7468_if_leA*node_7468_if_leB)), _TwoTargetLine ),0);
            }
            ENDCG
        }
		Pass
             {
                 Blend SrcAlpha OneMinusSrcAlpha
                 ZWrite Off
                 ZTest Greater
                 Lighting Off
                 //SetTexture [_SeeTroughTex] {combine texture}
				 Color [_RimColor]
             }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Roughness;
            uniform float4 _Tint;
            uniform fixed _UseMetalicTexture;
            uniform sampler2D _MetalicTexture; uniform float4 _MetalicTexture_ST;
            uniform fixed _UseRoughnessTexture;
            uniform sampler2D _RoughnessTexture; uniform float4 _RoughnessTexture_ST;
            uniform float _RoughnessMutiplier;
            uniform float _NormalMapMultiplier;
            uniform fixed _UseEmmisiveTexture;
            uniform sampler2D _EmmissiveTexture; uniform float4 _EmmissiveTexture_ST;
            uniform float _EmmissiveMultiplier;
            uniform float _Brightness;
            uniform float _RoughnessAdd;
            uniform float4 _RimColor;
            uniform float4 _RimColor2;
            uniform fixed _TwoTargetColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = lerp(float3(0,0,1),_BumpMap_var.rgb,_NormalMapMultiplier);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _RoughnessTexture_var = tex2D(_RoughnessTexture,TRANSFORM_TEX(i.uv0, _RoughnessTexture));
                float gloss = 1.0 - lerp( _Roughness, saturate(((_RoughnessTexture_var.r*_RoughnessMutiplier)+_RoughnessAdd)), _UseRoughnessTexture ); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_3245 = ((_MainTex_var.rgb*_Tint.rgb)+_Brightness);
                float node_7446 = (pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*20.0);
                float node_4479_if_leA = step(i.uv0.r,0.5);
                float node_4479_if_leB = step(0.5,i.uv0.r);
                float node_3437 = 0.0;
                float3 diffuseColor = lerp( saturate(lerp(node_3245,_RimColor.rgb,node_7446)), saturate(lerp(node_3245,lerp(_RimColor.rgb,_RimColor2.rgb,lerp((node_4479_if_leA*1.0)+(node_4479_if_leB*node_3437),node_3437,node_4479_if_leA*node_4479_if_leB)),node_7446)), _TwoTargetColor ); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                float4 _MetalicTexture_var = tex2D(_MetalicTexture,TRANSFORM_TEX(i.uv0, _MetalicTexture));
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, lerp( _Metallic, _MetalicTexture_var.r, _UseMetalicTexture ), specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _EmmissiveTexture_var = tex2D(_EmmissiveTexture,TRANSFORM_TEX(i.uv0, _EmmissiveTexture));
                float3 emissive = lerp( float3(0,0,0), (_EmmissiveTexture_var.rgb*_EmmissiveMultiplier), _UseEmmisiveTexture );
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
			
            ENDCG
        }
		
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Roughness;
            uniform float4 _Tint;
            uniform fixed _UseMetalicTexture;
            uniform sampler2D _MetalicTexture; uniform float4 _MetalicTexture_ST;
            uniform fixed _UseRoughnessTexture;
            uniform sampler2D _RoughnessTexture; uniform float4 _RoughnessTexture_ST;
            uniform float _RoughnessMutiplier;
            uniform float _NormalMapMultiplier;
            uniform fixed _UseEmmisiveTexture;
            uniform sampler2D _EmmissiveTexture; uniform float4 _EmmissiveTexture_ST;
            uniform float _EmmissiveMultiplier;
            uniform float _Brightness;
            uniform float _RoughnessAdd;
            uniform float4 _RimColor;
            uniform float4 _RimColor2;
            uniform fixed _TwoTargetColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = lerp(float3(0,0,1),_BumpMap_var.rgb,_NormalMapMultiplier);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _RoughnessTexture_var = tex2D(_RoughnessTexture,TRANSFORM_TEX(i.uv0, _RoughnessTexture));
                float gloss = 1.0 - lerp( _Roughness, saturate(((_RoughnessTexture_var.r*_RoughnessMutiplier)+_RoughnessAdd)), _UseRoughnessTexture ); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_3245 = ((_MainTex_var.rgb*_Tint.rgb)+_Brightness);
                float node_7446 = (pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*20.0);
                float node_4479_if_leA = step(i.uv0.r,0.5);
                float node_4479_if_leB = step(0.5,i.uv0.r);
                float node_3437 = 0.0;
                float3 diffuseColor = lerp( saturate(lerp(node_3245,_RimColor.rgb,node_7446)), saturate(lerp(node_3245,lerp(_RimColor.rgb,_RimColor2.rgb,lerp((node_4479_if_leA*1.0)+(node_4479_if_leB*node_3437),node_3437,node_4479_if_leA*node_4479_if_leB)),node_7446)), _TwoTargetColor ); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                float4 _MetalicTexture_var = tex2D(_MetalicTexture,TRANSFORM_TEX(i.uv0, _MetalicTexture));
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, lerp( _Metallic, _MetalicTexture_var.r, _UseMetalicTexture ), specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Metallic;
            uniform float _Roughness;
            uniform float4 _Tint;
            uniform fixed _UseMetalicTexture;
            uniform sampler2D _MetalicTexture; uniform float4 _MetalicTexture_ST;
            uniform fixed _UseRoughnessTexture;
            uniform sampler2D _RoughnessTexture; uniform float4 _RoughnessTexture_ST;
            uniform float _RoughnessMutiplier;
            uniform fixed _UseEmmisiveTexture;
            uniform sampler2D _EmmissiveTexture; uniform float4 _EmmissiveTexture_ST;
            uniform float _EmmissiveMultiplier;
            uniform float _Brightness;
            uniform float _RoughnessAdd;
            uniform float4 _RimColor;
            uniform float4 _RimColor2;
            uniform fixed _TwoTargetColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _EmmissiveTexture_var = tex2D(_EmmissiveTexture,TRANSFORM_TEX(i.uv0, _EmmissiveTexture));
                o.Emission = lerp( float3(0,0,0), (_EmmissiveTexture_var.rgb*_EmmissiveMultiplier), _UseEmmisiveTexture );
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_3245 = ((_MainTex_var.rgb*_Tint.rgb)+_Brightness);
                float node_7446 = (pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*20.0);
                float node_4479_if_leA = step(i.uv0.r,0.5);
                float node_4479_if_leB = step(0.5,i.uv0.r);
                float node_3437 = 0.0;
                float3 diffColor = lerp( saturate(lerp(node_3245,_RimColor.rgb,node_7446)), saturate(lerp(node_3245,lerp(_RimColor.rgb,_RimColor2.rgb,lerp((node_4479_if_leA*1.0)+(node_4479_if_leB*node_3437),node_3437,node_4479_if_leA*node_4479_if_leB)),node_7446)), _TwoTargetColor );
                float specularMonochrome;
                float3 specColor;
                float4 _MetalicTexture_var = tex2D(_MetalicTexture,TRANSFORM_TEX(i.uv0, _MetalicTexture));
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, lerp( _Metallic, _MetalicTexture_var.r, _UseMetalicTexture ), specColor, specularMonochrome );
                float4 _RoughnessTexture_var = tex2D(_RoughnessTexture,TRANSFORM_TEX(i.uv0, _RoughnessTexture));
                float roughness = lerp( _Roughness, saturate(((_RoughnessTexture_var.r*_RoughnessMutiplier)+_RoughnessAdd)), _UseRoughnessTexture );
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
