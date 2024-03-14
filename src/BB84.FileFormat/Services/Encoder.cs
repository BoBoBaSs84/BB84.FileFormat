using BB84.FileFormat.Exceptions;
using BB84.FileFormat.Interfaces;

namespace BB84.FileFormat.Services;

/// <summary>
/// The encoder class.
/// </summary>
internal sealed class Encoder : IEncoder
{
	/// <inheritdoc/>
	public byte[] Encode(File file)
	{
		try
		{
			using MemoryStream stream = new();
			using BinaryWriter writer = new(stream);

			writer.Write(File.Magic);
			writer.Write((ulong)file.TimeStamp.Ticks);
			writer.Write((uint)file.Header.Purpose);
			writer.Write(file.Header.DataLength);
			writer.Write(file.Data);

			return stream.ToArray();
		}
		catch (Exception ex)
		{
			throw new EncoderException("Encoding error occurred!", ex);
		}
	}
}
