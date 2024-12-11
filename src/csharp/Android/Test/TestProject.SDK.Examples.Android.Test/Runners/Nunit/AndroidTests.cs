﻿using NUnit.Framework;
using System.Reflection;
using TestProject.SDK.Examples.Android.Test;

namespace TestProject.SDK.Examples.Android.Runners.Nunit
{
	[TestFixture]
	public class AndroidTests
	{
		public static string DevToken = "YOUR_DEV_TOKEN";
		public static string DeviceUDID = "YOUR_DEVICE_UDID";
		public static string PackageName = "io.testproject.demo";
		public static string ActivityName = ".MainActivity";

		Runner runner;

		[SetUp]
		public void SetUp()
		{
			runner = new RunnerBuilder(DevToken).AsAndroid(DeviceUDID, PackageName, ActivityName).Build();
		}

		[TearDown]
		public void TearDown()
		{
			runner.Dispose();
		}

		[Test]
		public void RunBasicTest()
		{
			runner.Run(new BasicTest());
		}

		[Test]
		public void RunExtendedTest()
		{
			// Run the extended test with default values
			runner.Run(new ExtendedTest(), true);
		}

		[Test]
		public void RunProxyTest()
		{
			/**
			* Load proxy assembly into memory to allow SDK finding it's classes
			* This is only required when running the action proxy in Debug mode via IDE
			* This not not needed when running from TestProject platform
			*/
			Assembly.LoadFrom("AddonProxy.dll");
			runner.Run(new ProxyTest(), true);
		}
	}
}