using BB84.FileFormat.Exceptions;
using BB84.FileFormat.Services;

namespace BB84.FileFormat.Tests.Services;

[TestClass]
public class DecoderTests
{
	private static readonly string FilePath = Path.Combine(AppContext.BaseDirectory, "Test.bb84");

	[TestMethod]
	[ExpectedException(typeof(DecoderException))]
	public void DecodeFileFormatExceptionTest()
		=> new Decoder().Decode([55, 55, 55, 55]);

	[TestMethod]
	public void DecodeFileByBytesTest()
	{
		byte[] fileData = [66, 66, 56, 52, 136, 60, 86, 181, 98, 68, 220, 8, 1, 0, 0, 0, 0, 0, 0, 0];

		File file = new Decoder().Decode(fileData);

		Assert.IsNotNull(file);
		Assert.AreNotEqual(DateTime.MinValue, file.TimeStamp);
		Assert.IsTrue(file.Header.Purpose.HasFlag(Purpose.Storage));
		Assert.AreEqual(file.Header.DataLength, 0u);
		Assert.AreEqual(file.Data.Length, 0);
	}

	[TestMethod]
	public void DecodeFileByPath()
	{
		Decoder decoder = new();

		File file = decoder.Decode(FilePath);

		Assert.IsNotNull(file);
	}

	[TestMethod]
	public void DecodeFileByFileStream()
	{
		using FileStream stream = new(FilePath, FileMode.Open, FileAccess.Read);
		Decoder decoder = new();

		File file = decoder.Decode(stream);

		Assert.IsNotNull(file);
	}
}