using FluentAssertions;
using System;
using Xunit;

namespace LightInject.FactoryDependencies
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			var container = new ServiceContainer();

			container.RegisterSingleton<Service>();

			var instance = container.GetInstance<Service>();
			instance.Should().NotBeNull();

			instance.Dependency.Target.Should().BeOfType<ServiceContainer>();
		}

		public sealed class Service
		{
			public Service(Func<int, DateTime> dependency) => Dependency = dependency;

			public Func<int, DateTime> Dependency { get; }
		}
	}
}
