using FluentAssertions;
using MediumTest.SetupExamples;
using Moq;
using System;
using Xunit;
using Moq.Protected;
using System.Text.RegularExpressions;

namespace MediumTest.Tests
{
	public class SetupExamples
	{
		#region METHODS

		[Fact]
		public void Example1()
		{
			var mock = new Mock<ISample>();

			// Check metoduna 1 değeri gönderildiğinde true dönmesini istiyoruz.
			mock.Setup(x => x.Check(1)).Returns(true);

			var result1 = mock.Object.Check(1); // TRUE
			var result2 = mock.Object.Check(2); // FALSE
		}

		[Fact]
		public void Example2()
		{
			var mock = new Mock<ISample>();

			// Check metoduna herhangi bir değer gönderildiğinde true dönmesini istiyoruz.
			mock.Setup(x => x.Check(It.IsAny<int>())).Returns(true);

			var result1 = mock.Object.Check(1); // TRUE
			var result2 = mock.Object.Check(2); // TRUE
		}

		[Fact]
		public void Example3()
		{
			var mock = new Mock<ISample>();

			/* Check metoduna 1 ile 10 (dahil) arasında bir değer gönderildiğinde 
			   true dönmesini istiyoruz. */
			mock.Setup(x => x.Check(It.IsInRange<int>(1, 10, Moq.Range.Inclusive)))
				.Returns(true);

			/* 1 ile 10 arasında 1 ve 10'ununda dahil olmasını istedğimiz için
			   Range.Inclusive kullandık. 
			   1 ve 10 dahil olsun istemeseydik Range.Exclusive kullanacaktık. */

			var result1 = mock.Object.Check(1);  // TRUE
			var result2 = mock.Object.Check(5);  // TRUE
			var result3 = mock.Object.Check(10); // TRUE
			var result4 = mock.Object.Check(11); // FALSE
		}

		[Fact]
		public void Example4()
		{
			// Arrange
			var mock = new Mock<ISample>();

			/* Calculate metoduna herhangi bir parametre gönderilmez ise
			   ArgumentNullException raise edilsin istiyoruz. */

			mock.Setup(x => x.Calculate(It.IsNotNull<int[]>())).Throws<ArgumentNullException>();


			// Act
			Action act = () => mock.Object.Calculate();

			// Assert

			/* Fluent assertion ile exception'unun 
			   raise edilip edilmediğini kontrol ediyoruz. */

			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Example7()
		{
			var mock = new Mock<ISample>();
			// Property'inin döneceği değeri run-time'da hesaplamak.
			mock.Setup(x => x.Name).Returns(() =>
			{
				Random rnd = new Random();
				var v = rnd.Next(1000, 20000);
				return $"{v}_RANDOM".ToLower();
			});

			var result = mock.Object.Name;
		}

		[Fact]
		public void Example8()
		{
			var mock = new Mock<ISample>();

			mock.Setup(x => x.FormatString(It.IsAny<string>()))
				.Returns((string x) => { return x.ToLower(); });

			var result = mock.Object.FormatString("EMRE HIZLI");
		}

		[Fact]
		public void Example9()
		{
			var mock = new Mock<ISample>();
			var st1 = new Something();
			var st2 = new Something();

			// st1'in referansına göre dönüş tipini true ayarladık.
			mock.Setup(x => x.DoSomething(ref st1)).Returns(true);

			var result1 = mock.Object.DoSomething(ref st1); // TRUE;
			var result2 = mock.Object.DoSomething(ref st2); // FALSE;
		}

		[Fact]
		public void Example10()
		{
			var mock = new Mock<ISample>();

			/* Metodu çağırdığı her seferinde farklı farklı değerler
			  */
			mock.SetupSequence(x => x.Count())
				.Returns(5)
				.Returns(10)
				.Returns(15);

			var result1 = mock.Object.Count(); // 5
			var result2 = mock.Object.Count(); // 10
			var result3 = mock.Object.Count(); // 15
		}

		[Fact]
		public void Example11()
		{
			var mock = new Mock<ISample>();
			/* String parametreler için regex tanımına uyanlara göre
			   return değerini mockladık. */
			mock.Setup(x => x.FormatString(It.IsRegex(@"[\D\d]{6}", RegexOptions.IgnoreCase)))
				.Returns("Emre");

			var result1 = mock.Object.FormatString("a1b2c3"); // Emre
			var result2 = mock.Object.FormatString("aaa");    // null
		}

		[Fact]
		public void Example12()
		{
			var mock = new Mock<Something>();

			/* Bu şekilde mocklama yapamayız. Bar metodu overridable değil. 
			   Bu nedenle mock objemize interface tipi üzerinden mocklama
			   yapmamız gerekiyor. As<> kullanarak bunu sağlayabiliyoruz. 

			mock.Setup(x => x.Bar()).Returns("Emre");

			*/
			mock.As<IBar>().Setup(x => x.Bar()).Returns("Hızlı");
			IBar something = mock.Object;

			var result1 = something.Bar(); // Hızlı
		}

		[Fact]
		public void Example13()
		{
			var mock = new Mock<Something>();
			mock.CallBase = true;

			var result1 = mock.Object.DoSomestring(); // Emre
		}

		#endregion

		#region PROPERTIES

		[Fact]
		public void Example5()
		{
			var mock = new Mock<ISample>();
			// Property'lerin dönmesini istediğimiz değerlerini set edebiliriz.
			mock.SetupProperty(x => x.Lastname, "Emre");

			var result = mock.Object.Lastname; // Emre
		}

		[Fact]
		public void Example6()
		{
			var mock = new Mock<ISample>();
			/* Setter'ı olmayan property'lerin dönmesini 
			   istediğimiz değerlerini getter'ını mocklayabiliriz. */
			mock.SetupGet(x => x.Name).Returns("Emre");

			var result = mock.Object.Name; // Emre
		}

		#endregion

		#region VERIFICATION

		[Fact]
		public void Exam1()
		{
			var mock = new Mock<ISample>();

			mock.Object.Lastname = "Emre";
			/* İşimiz bittiğinde nesneleri property'lerinin set edilip
			   edilmediğini kontrol edebilir. */
			mock.VerifySet(x => x.Lastname = "Emre");
		}

		[Fact]
		public void Exam2()
		{
			var mock = new Mock<ISample>();

			var name = mock.Object.Name;

			/* İstediğimiz property'nin değerinin read edilip edilmediğini
			   kontrol edebilir. */
			mock.VerifyGet(x => x.Name);
		}

		#endregion
	}
}