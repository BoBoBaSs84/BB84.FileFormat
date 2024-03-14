using BB84.FileFormat.Exceptions;
using BB84.FileFormat.Services;

namespace BB84.FileFormat.Tests.Services;

[TestClass]
public class EncoderTests
{
	[TestMethod]
	public void EncodeTest()
	{
		File file = new(DateTime.UtcNow, new(Purpose.Storage | Purpose.Information, 0), []);

		Encoder encoder = new();
		byte[] data = encoder.Encode(file);

		Assert.IsNotNull(data);
	}

	[TestMethod]
	[ExpectedException(typeof(EncoderException))]
	public void EncodeEncoderExceptionTest()
		=> new Encoder().Encode(default!);
}