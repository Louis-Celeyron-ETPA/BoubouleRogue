﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LCStarterContent
{
    namespace Common
    {
        public static class UsualFunction 
        {
            #region MakeTex
            ///<summary>
            /// Create a simple texture with a color 
            ///</summary>
            public static Texture2D MakeTex (int width, int height, Color col)
	        {
		        Color[] pix = new Color[width * height];
		        for( int i = 0; i < pix.Length; ++i )
		        {
			        pix[ i ] = col;
		        }
		        Texture2D result = new Texture2D( width, height );
		        result.SetPixels( pix );
		        result.Apply();
    	        return result;	
	        }
	        ///<summary>
	        /// Create a simple texture with a color and a 1px border 
	        ///</summary>
	        public static Texture2D MakeTex (int width, int height, Color col, Color borderColor)
	        {
		        Color[] pix = new Color[width* height];
		        for( int i = 0; i < pix.Length; ++i )
		        {
			        pix[ i ] = col;
		        }
		        for( int i = 0; i < width; ++i )
		        {
			        pix[ i ] = borderColor;
		        }
		
		        for( int i = width; i < pix.Length-width-1; i+=width )
		        {
			        pix[ i-1 ] = borderColor;

			        pix[ i ] = borderColor;
		        }
		        for( int i = pix.Length-width-1; i < pix.Length; ++i )
		        {
			        pix[ i ] = borderColor;
		        }
		        Texture2D result = new Texture2D( width, height);
		        result.SetPixels( pix );
		        result.Apply();
    	        return result;	
	        }
	        ///<summary>
	        /// Create a simple texture with a color and a custom size border
	        ///</summary>
	        public static Texture2D MakeTex (int width, int height, Color col, Color borderColor, int borderSize)
	        {
		        Color[] pix = new Color[width* height];
		        for( int i = 0; i < pix.Length; ++i )
		        {
			        pix[ i ] = col;
		        }
		        for( int i = 0; i < width*borderSize; ++i )
		        {
			        pix[ i ] = borderColor;
		        }
		
		        for( int i = width; i < pix.Length-width-1; i+=width )
		        {
			        for(var y = 0; y<borderSize; y++)
			        {
				        pix[ i-1*y-1 ] = borderColor;
				        pix[ i+y ] = borderColor;
			        }
		        }
		        for( int i = pix.Length-width*borderSize-1; i < pix.Length; ++i )
		        {
			        pix[ i ] = borderColor;
		        }
		        Texture2D result = new Texture2D( width, height);
		        result.SetPixels( pix );
		        result.Apply();
    	        return result;	
	        }
            #endregion

            /// <summary>
            /// Do Absolutly nothing, we never know like for a ? function or something i dunno
            /// </summary>
            public static void DoNothing()
            {

            }
        }
    }
}
