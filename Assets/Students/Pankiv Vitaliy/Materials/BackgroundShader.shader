Shader "Custom/BackgroundShader"
{
    Properties
    {
        _dithering ("Dithering Power", Float) = 0
        _pixelation ("Pixel resolution", Vector) = (0, 0, 0, 0)
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

            float2 _pixelation;
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
                const float how_could_i_call_it = cos(_Time * _CosTime * 2 + i.uv.x / _pixelation.x * _SinTime * UNITY_HALF_PI);
                i.uv = floor(i.uv * _pixelation);
                i.uv.y += sin(i.uv.x) * how_could_i_call_it * _dithering / _pixelation.y;
                i.uv /= _pixelation;
                const fixed4 col = lerp(_colorBottom, _colorTop, i.uv.y * 0.9f);
                return col;
            }
            ENDCG
        }
    }
}
