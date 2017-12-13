﻿using System;
using System.Collections.Generic;
using Xunit;

namespace SkiaSharp.Tests
{
	public class GRContextTest : SKTest
	{
		[Fact]
		public void CreateDefaultContextIsValid()
		{
			using (var ctx = CreateGlContext()) {
				ctx.MakeCurrent();

				var grContext = GRContext.Create(GRBackend.OpenGL);

				Assert.NotNull(grContext);
			}
		}

		[Fact]
		public void CreateSpecificContextIsValid()
		{
			using (var ctx = CreateGlContext()) {
				ctx.MakeCurrent();

				var glInterface = GRGlInterface.CreateNativeGlInterface();

				Assert.True(glInterface.Validate());

				var grContext = GRContext.Create(GRBackend.OpenGL, glInterface);

				Assert.NotNull(grContext);
			}
		}

		[Fact]
		public void GpuSurfaceIsCreated()
		{
			using (var ctx = CreateGlContext()) {
				ctx.MakeCurrent();

				using (var grContext = GRContext.Create(GRBackend.OpenGL))
				using (var surface = SKSurface.Create(grContext, true, new SKImageInfo(100, 100))) {
					Assert.NotNull(surface);

					var canvas = surface.Canvas;
					Assert.NotNull(canvas);

					canvas.Clear(SKColors.Transparent);
				}
			}
		}
	}
}
