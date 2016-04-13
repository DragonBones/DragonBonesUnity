using UnityEngine;
using System.Collections.Generic;
using System;


namespace DragonBones
{


  public class DragonBones  {

		public  const float PI = 3.14159265358979323846f;
		public  const float ANGLE_TO_RADIAN = PI / 180.0f;
		public  const float RADIAN_TO_ANGLE = 180.0f / PI;
		
		public  const float AUTO_TWEEN_EASING = 10.0f;
		public  const float NO_TWEEN_EASING = 20.0f;
		public  const float USE_FRAME_TWEEN_EASING = 30.0f;

		public static float round(float value)
		{
			return (value > 0.0f) ? (float)Math.Floor(value + 0.5f) : (float)Math.Ceiling(value - 0.5f);
		}
		
		public static  float formatRadian(float radian)
		{
            
			radian =  radian % (PI * 2.0f);
			
			if (radian > PI)
			{
				radian -= PI * 2.0f;
			}
			
			if (radian < -PI)
			{
				radian += PI * 2.0f;
			}
			
			return radian;
		}
		
		public static  float getEaseValue(float value, float easing)
		{
			float valueEase = 1.0f;
			
			if (easing > 1)    // ease in out
			{
				valueEase = 0.5f * (1.0f - (float)Math.Cos(value * PI));
				easing -= 1.0f;
			}
			else if (easing > 0)    // ease out
			{
				valueEase = 1.0f - (float)Math.Pow(1.0f - value, 2);
			}
			else if (easing < 0)    // ease in
			{
				easing *= -1.0f;
				valueEase =  (float)Math.Pow(value, 2);
			}
			
			return (valueEase - value) * easing + value;
		}
		

	   
		
		public  enum  DisplayType {DT_IMAGE, DT_ARMATURE, DT_FRAME, DT_1, DT_2, DT_3, DT_4, DT_5};
		public static  DisplayType getDisplayTypeByString(string displayType)
		{
			if (displayType == "image")
			{
				return DisplayType.DT_IMAGE;
			}
			else if (displayType == "armature")
			{
				return DisplayType.DT_ARMATURE;
			}
			else if (displayType == "frame")
			{
				return DisplayType.DT_FRAME;
			}
			
			return DisplayType.DT_IMAGE;
		}
		
		public  enum  BlendMode {BM_ADD, BM_ALPHA, BM_DARKEN, BM_DIFFERENCE, BM_ERASE, BM_HARDLIGHT, BM_INVERT, BM_LAYER, BM_LIGHTEN, BM_MULTIPLY, BM_NORMAL, BM_OVERLAY, BM_SCREEN, BM_SHADER, BM_SUBTRACT};
		public static  BlendMode getBlendModeByString(string blendMode)
		{
			if (blendMode == "normal")
			{
				return BlendMode.BM_NORMAL;
			}
			else if (blendMode == "add")
			{
				return BlendMode.BM_ADD;
			}
			else if (blendMode == "alpha")
			{
				return BlendMode.BM_ALPHA;
			}
			else if (blendMode == "darken")
			{
				return BlendMode.BM_DARKEN;
			}
			else if (blendMode == "difference")
			{
				return BlendMode.BM_DIFFERENCE;
			}
			else if (blendMode == "erase")
			{
				return BlendMode.BM_ERASE;
			}
			else if (blendMode == "hardlight")
			{
				return BlendMode.BM_HARDLIGHT;
			}
			else if (blendMode == "invert")
			{
				return BlendMode.BM_INVERT;
			}
			else if (blendMode == "layer")
			{
				return BlendMode.BM_LAYER;
			}
			else if (blendMode == "lighten")
			{
				return BlendMode.BM_LIGHTEN;
			}
			else if (blendMode == "multiply")
			{
				return BlendMode.BM_MULTIPLY;
			}
			else if (blendMode == "overlay")
			{
				return BlendMode.BM_OVERLAY;
			}
			else if (blendMode == "screen")
			{
				return BlendMode.BM_SCREEN;
			}
			else if (blendMode == "shader")
			{
				return BlendMode.BM_SHADER;
			}
			else if (blendMode == "subtract")
			{
				return BlendMode.BM_SUBTRACT;
			}
			
			return BlendMode.BM_NORMAL;
		}




  }
}