Shader "Custom/BackgroundShader"
{
    Properties
    {
        _dithering ("Dithering Power", Float) = 0
        _pixelationX ("Pixel resolution X", Float) = 1
        _pixelationY ("Pixel resolution Y", Float) = 1
        _colorTop ("Color Top", Color) = (0, 0, 0, 1)
        _colorBottom ("Color Bottom", Color) = (1, 1, 1, 1)
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
            float4 _colorTop;
            float4 _colorBottom;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                const float2 pixelation = float2(_pixelationX, _pixelationY);
                i.uv = floor(i.uv * pixelation);
                i.uv.y += sign(sin(i.uv.x)) * _dithering / _pixelationX + sin(_Time * 20) * _dithering / _pixelationY;
                i.uv.x += sign(cos(i.uv.y)) * _dithering / _pixelationY + cos(_Time * 10) * _dithering / _pixelationX;
                i.uv /= pixelation;
                const fixed4 col = lerp(_colorBottom, _colorTop, i.uv.y * 1.1f);
                return col;
            }
            ENDCG
        }
    }
}
