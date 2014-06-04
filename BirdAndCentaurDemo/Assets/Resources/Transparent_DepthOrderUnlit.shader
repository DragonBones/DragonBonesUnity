Shader "Transparent/Depth Ordered Unlit" {

 

    Properties {

        _Color ("Main Color", Color) = (1,1,1,1)

        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}

    }

 

    Category {

        Lighting off

        Cull off

        Tags {"Queue" = "Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}

 

                

 

        SubShader {

            ZWrite On

            Alphatest Greater 0

            Blend SrcAlpha OneMinusSrcAlpha

 

            Pass {

                SetTexture [_MainTex] {

                    constantColor [_Color]

                    Combine texture * constant

                }

            }

        }

    }

}