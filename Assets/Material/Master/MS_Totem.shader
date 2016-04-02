// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-4867-OUT,spec-4486-OUT,gloss-6178-OUT,normal-457-OUT,emission-1579-OUT,clip-7736-A;n:type:ShaderForge.SFN_Tex2d,id:7736,x:29944,y:32209,ptovrint:True,ptlb:Diffuse,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3b94a9270695a48438d1186170274055,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:31893,y:33503,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:87c6ec8832da0b74abd8cf168f540cbb,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:31712,y:32620,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:31725,y:32985,ptovrint:False,ptlb:Roughness,ptin:_Roughness,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:9837,x:30236,y:32209,varname:node_9837,prsc:2|A-7736-RGB,B-327-RGB;n:type:ShaderForge.SFN_Color,id:327,x:29944,y:32403,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:3245,x:30564,y:32210,varname:node_3245,prsc:2|A-9837-OUT,B-1101-OUT;n:type:ShaderForge.SFN_Clamp01,id:1994,x:30745,y:32210,varname:node_1994,prsc:2|IN-3245-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:4486,x:32133,y:32620,ptovrint:False,ptlb:Use Metalic Texture,ptin:_UseMetalicTexture,varname:node_4486,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-358-OUT,B-6672-R;n:type:ShaderForge.SFN_Tex2d,id:6672,x:31780,y:32726,ptovrint:False,ptlb:Metalic Texture,ptin:_MetalicTexture,varname:node_6672,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_SwitchProperty,id:6178,x:32124,y:32986,ptovrint:False,ptlb:Use Roughness Texture,ptin:_UseRoughnessTexture,varname:node_6178,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-1813-OUT,B-8714-OUT;n:type:ShaderForge.SFN_Tex2d,id:9474,x:31234,y:33081,ptovrint:False,ptlb:Roughness Texture,ptin:_RoughnessTexture,varname:node_9474,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:44,x:31234,y:33291,ptovrint:False,ptlb:Roughness Mutiplier,ptin:_RoughnessMutiplier,varname:node_44,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:9918,x:31491,y:33156,varname:node_9918,prsc:2|A-9474-R,B-44-OUT;n:type:ShaderForge.SFN_Clamp01,id:8714,x:31894,y:33155,varname:node_8714,prsc:2|IN-5011-OUT;n:type:ShaderForge.SFN_Vector3,id:9311,x:31893,y:33388,varname:node_9311,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Lerp,id:457,x:32142,y:33484,varname:node_457,prsc:2|A-9311-OUT,B-5964-RGB,T-1838-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1838,x:31893,y:33712,ptovrint:False,ptlb:Normal Map Multiplier,ptin:_NormalMapMultiplier,varname:node_1838,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:1101,x:30248,y:32398,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_1101,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:5011,x:31694,y:33155,varname:node_5011,prsc:2|A-9918-OUT,B-391-OUT;n:type:ShaderForge.SFN_ValueProperty,id:391,x:31442,y:33380,ptovrint:False,ptlb:Roughness Add,ptin:_RoughnessAdd,varname:node_391,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:3085,x:30618,y:31333,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_3085,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3700b66e83c010140adeb349d54c915d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:1374,x:30034,y:31772,varname:node_1374,prsc:2,uv:0;n:type:ShaderForge.SFN_ComponentMask,id:8596,x:30294,y:31773,varname:node_8596,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-1374-V;n:type:ShaderForge.SFN_Slider,id:7914,x:29938,y:31599,ptovrint:False,ptlb:AmmountFish,ptin:_AmmountFish,varname:node_7914,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:100;n:type:ShaderForge.SFN_Add,id:5624,x:30999,y:31652,varname:node_5624,prsc:2|A-2976-OUT,B-9266-OUT;n:type:ShaderForge.SFN_Multiply,id:4836,x:31370,y:31596,varname:node_4836,prsc:2|A-3085-R,B-3569-OUT;n:type:ShaderForge.SFN_OneMinus,id:9266,x:30740,y:31759,varname:node_9266,prsc:2|IN-1995-OUT;n:type:ShaderForge.SFN_Lerp,id:4867,x:31862,y:31543,varname:node_4867,prsc:2|A-7071-OUT,B-1119-RGB,T-4836-OUT;n:type:ShaderForge.SFN_Clamp01,id:3569,x:31161,y:31652,varname:node_3569,prsc:2|IN-5624-OUT;n:type:ShaderForge.SFN_Lerp,id:7071,x:31370,y:31438,varname:node_7071,prsc:2|A-1994-OUT,B-7127-RGB,T-3085-R;n:type:ShaderForge.SFN_Color,id:7127,x:31051,y:31091,ptovrint:False,ptlb:Color NoFish,ptin:_ColorNoFish,varname:node_7127,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:1119,x:31559,y:31121,ptovrint:False,ptlb:Color WithFish,ptin:_ColorWithFish,varname:node_1119,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.08627451,c4:1;n:type:ShaderForge.SFN_Vector1,id:1200,x:31051,y:31264,varname:node_1200,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:7748,x:31321,y:30880,varname:node_7748,prsc:2|A-1200-OUT,B-7127-RGB,T-3085-R;n:type:ShaderForge.SFN_Lerp,id:1372,x:31862,y:30878,varname:node_1372,prsc:2|A-7748-OUT,B-1119-RGB,T-4836-OUT;n:type:ShaderForge.SFN_Divide,id:2845,x:30417,y:31596,varname:node_2845,prsc:2|A-7914-OUT,B-6308-OUT;n:type:ShaderForge.SFN_Vector1,id:6308,x:30127,y:31686,varname:node_6308,prsc:2,v1:22;n:type:ShaderForge.SFN_Add,id:2976,x:30736,y:31591,varname:node_2976,prsc:2|A-2845-OUT,B-923-OUT;n:type:ShaderForge.SFN_Vector1,id:923,x:30549,y:31635,varname:node_923,prsc:2,v1:-1;n:type:ShaderForge.SFN_Multiply,id:1995,x:30549,y:31773,varname:node_1995,prsc:2|A-8596-OUT,B-806-OUT;n:type:ShaderForge.SFN_Vector1,id:806,x:30294,y:31931,varname:node_806,prsc:2,v1:4;n:type:ShaderForge.SFN_Divide,id:1579,x:32040,y:30982,varname:node_1579,prsc:2|A-1372-OUT,B-5534-OUT;n:type:ShaderForge.SFN_Vector1,id:3285,x:31574,y:30633,varname:node_3285,prsc:2,v1:10;n:type:ShaderForge.SFN_Add,id:5534,x:31830,y:30633,varname:node_5534,prsc:2|A-3285-OUT,B-858-OUT;n:type:ShaderForge.SFN_OneMinus,id:858,x:31598,y:30732,varname:node_858,prsc:2|IN-8749-OUT;n:type:ShaderForge.SFN_Slider,id:8749,x:31267,y:30732,ptovrint:False,ptlb:Emmisive Intensity,ptin:_EmmisiveIntensity,varname:node_8749,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;proporder:7736-327-1101-5964-1838-1813-6178-9474-44-391-4486-6672-358-3085-7914-7127-1119-8749;pass:END;sub:END;*/

Shader "Shader Forge/MS_Totem" {
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
        _Mask ("Mask", 2D) = "white" {}
        _AmmountFish ("AmmountFish", Range(0, 100)) = 0
        _ColorNoFish ("Color NoFish", Color) = (1,0,0,1)
        _ColorWithFish ("Color WithFish", Color) = (0,1,0.08627451,1)
        _EmmisiveIntensity ("Emmisive Intensity", Range(0, 10)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            uniform float _Brightness;
            uniform float _RoughnessAdd;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _AmmountFish;
            uniform float4 _ColorNoFish;
            uniform float4 _ColorWithFish;
            uniform float _EmmisiveIntensity;
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
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
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
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float node_4836 = (_Mask_var.r*saturate((((_AmmountFish/22.0)+(-1.0))+(1.0 - (i.uv0.g.r*4.0)))));
                float3 diffuseColor = lerp(lerp(saturate(((_MainTex_var.rgb*_Tint.rgb)+_Brightness)),_ColorNoFish.rgb,_Mask_var.r),_ColorWithFish.rgb,node_4836); // Need this for specular when using metallic
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
                float node_1200 = 0.0;
                float3 emissive = (lerp(lerp(float3(node_1200,node_1200,node_1200),_ColorNoFish.rgb,_Mask_var.r),_ColorWithFish.rgb,node_4836)/(10.0+(1.0 - _EmmisiveIntensity)));
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
            uniform float _Brightness;
            uniform float _RoughnessAdd;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _AmmountFish;
            uniform float4 _ColorNoFish;
            uniform float4 _ColorWithFish;
            uniform float _EmmisiveIntensity;
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
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
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
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float node_4836 = (_Mask_var.r*saturate((((_AmmountFish/22.0)+(-1.0))+(1.0 - (i.uv0.g.r*4.0)))));
                float3 diffuseColor = lerp(lerp(saturate(((_MainTex_var.rgb*_Tint.rgb)+_Brightness)),_ColorNoFish.rgb,_Mask_var.r),_ColorWithFish.rgb,node_4836); // Need this for specular when using metallic
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
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
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
            uniform float _Brightness;
            uniform float _RoughnessAdd;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _AmmountFish;
            uniform float4 _ColorNoFish;
            uniform float4 _ColorWithFish;
            uniform float _EmmisiveIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float node_1200 = 0.0;
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float node_4836 = (_Mask_var.r*saturate((((_AmmountFish/22.0)+(-1.0))+(1.0 - (i.uv0.g.r*4.0)))));
                o.Emission = (lerp(lerp(float3(node_1200,node_1200,node_1200),_ColorNoFish.rgb,_Mask_var.r),_ColorWithFish.rgb,node_4836)/(10.0+(1.0 - _EmmisiveIntensity)));
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffColor = lerp(lerp(saturate(((_MainTex_var.rgb*_Tint.rgb)+_Brightness)),_ColorNoFish.rgb,_Mask_var.r),_ColorWithFish.rgb,node_4836);
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
