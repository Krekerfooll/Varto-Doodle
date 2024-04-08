Shader "Custom/BackgroundShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _dithering ("Dithering Power", Float) = 0
        _pixelationX ("Pixel resolution X", Float) = 1
        _pixelationY ("Pixel resolution Y", Float) = 1
        _color ("Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _pixelationX;
            float _pixelationY;
            float _dithering;
            float4 _color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target // Якесь таке страхопудало вийшло, методом тику
            {
                const float2 pixelation = float2(_pixelationX, _pixelationY);
                i.uv = floor(i.uv * pixelation);
                i.uv.y += (i.uv.x % 2 == 0 ? -1 : 1) / _pixelationY * _dithering * 2;
                i.uv.x += (i.uv.y % 2 == 0 ? -1 : 1) / _pixelationX * _dithering * 2;
                i.uv.y += (sin(_Time * _SinTime + i.uv.y) * cos(i.uv.x / _pixelationX + _Time)) + sin(_Time * 10) * cos(_Time * 5) * 10;
                i.uv.x += (cos(_Time * _SinTime + i.uv.y) * sin(i.uv.x / _pixelationX) + _Time) * _pixelationX;
                
                i.uv /= pixelation;
                const fixed4 col = tex2D(_MainTex, i.uv);
                return col * _color;
            }
            ENDCG
        }
    }
}
