﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;

namespace SkiaSharp.Tests
{
	public class SKColorSpaceTest : SKTest
	{
		[Fact]
		public void CanCreateSrgb()
		{
			var colorspace = SKColorSpace.CreateSrgb();

			Assert.NotNull(colorspace);
			Assert.True(SKColorSpace.Equal(colorspace, colorspace));
		}

		[Fact]
		public void ImageInfoHasColorSpace()
		{
			var colorspace = SKColorSpace.CreateSrgb();

			var info = new SKImageInfo(100, 100, SKImageInfo.PlatformColorType, SKAlphaType.Premul, colorspace);
			Assert.Equal(colorspace, info.ColorSpace);

			var image = SKImage.Create(info);
			Assert.Equal(colorspace, image.PeekPixels().ColorSpace);
		}

		[Fact]
		public void SrgbColorSpaceIsCloseToSrgb()
		{
			var colorspace = SKColorSpace.CreateSrgb();

			Assert.True(colorspace.GammaIsCloseToSrgb);
		}
	}
}
