Shader "Unlit/Grid"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Cell_Size("Cell Size", Vector) = (1,1,0,0)
        _Grid_Tickness("Grid_Tickness", float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float4 vertex_non_combert : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Cell_Size;
            float _Grid_Tickness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex_non_combert = v.vertex;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                float grid_X = fmod(abs(i.vertex_non_combert.x),_Cell_Size.x);
                grid_X = smoothstep(grid_X,_Grid_Tickness,0);

                float grid_Y = fmod(abs(i.vertex_non_combert.z),_Cell_Size.y);
                grid_Y = smoothstep(grid_Y,_Grid_Tickness,0);

                float grid = grid_X * grid_Y;

                float grid_inver = 1-grid;

                if(grid_inver < 1)
                {
                    clip(-1);
                }

                return grid;
                
            }
            ENDCG
        }
    }
}
