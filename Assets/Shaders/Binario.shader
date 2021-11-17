Shader "Custom/Binario"
{
    Properties
    {
        // _MainTex ("Texture", 2D) = "white" {}
        // _TanFac ("Tangent Factor", float) = 0.1

        _NumberColor ("Number Color", Color) = (0, 1, 0, 1)
        _Velocity ("Animation Velocity", float) = 0.1

        [NoScaleOffset] _CubeTex ("Cubemap", Cube) = "grey" {}
    }
    SubShader
    {
        Tags {  "RenderType"="Background"  // tag to inform the render pipeline of what type this is
                "Queue" = "Background"      // changes the render order
                "PreviewType" = "Plane" }  

        // Tags { "QUEUE"="Background" "RenderType"="Background" "PreviewType"="Skybox" }

        Pass
        {
            Tags { "QUEUE"="Background" "RenderType"="Background" "PreviewType"="Skybox" }
            // Tags { "QUEUE"="Background" "RenderType"="Background" "PreviewType"="Skybox" }

            Cull Off
            ZWrite Off
            // Blend One One
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // sampler2D _MainTex;
            // float4 _MainTex_ST;
            // float _TanFac;

            uniform samplerCUBE _CubeTex;
            float4 _CubeTex_HDR;
            float4 _NumberColor;
            float _Velocity;

            float3 RotateAroundXInDegrees(float3 vertex, float degrees)
            {
                float alpha = degrees * UNITY_PI / 180.0;
                float sinA, cosA;
                sincos(alpha, sinA, cosA);
                float2x2 m = float2x2(cosA, -sinA, sinA, cosA);
                return float3(mul(m, vertex.zy), vertex.x).zyx;
            }

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Interpolator
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
                float3 texcoord : TEXCOORD2;
            };


            Interpolator vert (MeshData v)
            {
                Interpolator o;
                
                // o.uv = TRANSFORM_TEX(v.uv, _MainTex); // textura 2d

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.texcoord = v.vertex.xyz;

                return o;
            }

            float4 frag (Interpolator i) : SV_Target
            {
                float velocity = _Time.y * _Velocity;
                
                // caso decida fazer com só um plano grandao pra caralho inves de usar skybox com cubemap etc
                // float3 uvOffseted = float3(i.texcoord.x, sin(i.texcoord.y + velocity), sin(i.texcoord.z + velocity));
                // float4 col = tex2D(_MainTex, uvOffseted);
                // col = col - float4(0, 0, 0, 1) * col > float4(0.8, 0.8, 0.8, 0.9);
                // col = col < float4(1, 1, 1, 1);
                // return col * _NumberColor;
                
                float3 rotated = RotateAroundXInDegrees(i.texcoord, (_Time.y * _Velocity));
                float4 tex = texCUBE(_CubeTex, rotated);
                tex *= 3.5; // scalona a textura, se for mt alto o numero caga a parada :P
                float3 c = DecodeHDR(tex, _CubeTex_HDR);
                c *= unity_ColorSpaceDouble.rgb;

                // transforma tudo que é branco em transparente, por ser skybox ele joga pra preto
                c = c - float4(0, 0, 0, 1) * (c > float4(0.8, 0.8, 0.8, 0.8)); // é a cor menos 1 no alpha value multiplicado por se é branco ou nao
                c = c < float4(1, 1, 1, 1); // por algum motivo isso funciona assim, nao entendi ainda sei la branchless é estranho

                return float4(c, 1) * _NumberColor;

            }
            ENDCG
        }
    }
}
