Shader "Custom/FogOfWar" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    _FogRadius ("FogRadius", Float) = 1.0
    _FogMaxRadius("FogMaxRadius", Float) = 0.5
    _Player1_Pos ("_Player1_Pos", Vector) = (0,0,0,1)
    _Player2_Pos ("_Player2_Pos", Vector) = (0,0,0,1)
    _Player3_Pos ("_Player3_Pos", Vector) = (0,0,0,1)
    _Player4_Pos ("_Player4_Pos", Vector) = (0,0,0,1)
    _Player5_Pos ("_Player5_Pos", Vector) = (0,0,0,1)
    _Player6_Pos ("_Player6_Pos", Vector) = (0,0,0,1)
    _Player7_Pos ("_Player7_Pos", Vector) = (0,0,0,1)
    _Player8_Pos ("_Player8_Pos", Vector) = (0,0,0,1)
    _Player9_Pos ("_Player9_Pos", Vector) = (0,0,0,1)
    _Player10_Pos ("_Player10_Pos", Vector) = (0,0,0,1)
    _Player11_Pos ("_Player11_Pos", Vector) = (0,0,0,1)
    _Player12_Pos ("_Player12_Pos", Vector) = (0,0,0,1)
    _Player13_Pos ("_Player13_Pos", Vector) = (0,0,0,1)
    _Player14_Pos ("_Player14_Pos", Vector) = (0,0,0,1)
    _Player15_Pos ("_Player15_Pos", Vector) = (0,0,0,1)
    _Player16_Pos ("_Player16_Pos", Vector) = (0,0,0,1)
}

SubShader {
    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
    LOD 600
    Blend SrcAlpha OneMinusSrcAlpha
    Cull Off

    CGPROGRAM
    #pragma surface surf Lambert vertex:vert

    sampler2D _MainTex;
    fixed4     _Color;
    float     _FogRadius;
    float     _FogMaxRadius;
    float4     _Player1_Pos;
    float4     _Player2_Pos;
    float4     _Player3_Pos;
    float4     _Player4_Pos;
    float4     _Player5_Pos;
    float4     _Player6_Pos;
    float4     _Player7_Pos;
    float4     _Player8_Pos;
    float4     _Player9_Pos;
    float4     _Player10_Pos;
    float4     _Player11_Pos;
    float4     _Player12_Pos;
    float4     _Player13_Pos;
    float4     _Player14_Pos;
    float4     _Player15_Pos;
    float4     _Player16_Pos;

    struct Input {
        float2 uv_MainTex;
        float2 location;
    };

    float powerForPos(float4 pos, float2 nearVertex);

    void vert(inout appdata_full vertexData, out Input outData) {
        float4 pos = mul(UNITY_MATRIX_MVP, vertexData.vertex);
        float4 posWorld = mul(_Object2World, vertexData.vertex);
        outData.uv_MainTex = vertexData.texcoord;
        outData.location = posWorld.xz;
    }

    void surf (Input IN, inout SurfaceOutput o) {
        fixed4 baseColor = tex2D(_MainTex, IN.uv_MainTex) * _Color;

        float alpha = max((1.0 - (baseColor.a + powerForPos(_Player1_Pos, IN.location) + powerForPos(_Player2_Pos, IN.location) + powerForPos(_Player3_Pos, IN.location)+ powerForPos(_Player4_Pos, IN.location)
        				+powerForPos(_Player5_Pos, IN.location) + powerForPos(_Player6_Pos, IN.location) + powerForPos(_Player7_Pos, IN.location)+ powerForPos(_Player8_Pos, IN.location)
        				+powerForPos(_Player9_Pos, IN.location) + powerForPos(_Player14_Pos, IN.location) + powerForPos(_Player15_Pos, IN.location)+ powerForPos(_Player16_Pos, IN.location)
        				+powerForPos(_Player10_Pos, IN.location) + powerForPos(_Player11_Pos, IN.location) + powerForPos(_Player12_Pos, IN.location)+ powerForPos(_Player13_Pos, IN.location)
        				)),0);

        o.Albedo = baseColor.rgb;
        o.Alpha = alpha;
    }

    //return 0 if (pos - nearVertex) > _FogRadius
    float powerForPos(float4 pos, float2 nearVertex) {
        float atten = clamp(_FogRadius - length(pos.xz - nearVertex.xy), 0.0, _FogRadius);

        return (1.0/_FogMaxRadius)*atten/_FogRadius;
    }

    ENDCG
}

Fallback "Transparent/VertexLit"
}