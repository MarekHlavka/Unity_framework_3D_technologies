Shader "Hidden/Blur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11, OpenGL ES 2.0 because it uses unsized arrays
#pragma exclude_renderers d3d11 gles
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;

            fixe4 getBorderVal(int[] kernel, int neigborhood){

            }



            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv);

                int neigborhood = 2;
                for(int row = -neigborhood; row <= neigborhood; row++){
                    for(int col = -neigborhood; col <= neigborhood; col++){

                        if(row != 0 && col != 0){
                            float2 local_pixel = i.uv + float2(_MainTex_TexelSize.x * col, _MainTex_TexelSize.y * row);
                            color = color + tex2D(_MainTex, local_pixel);
                        }
                    }
                }
                color = color / (10*((2*neigborhood + 1) * (2*neigborhood + 1)));

                return color;
            }
            ENDCG
        }
    }
}
