using BB84.FileFormat.Exceptions;
using BB84.FileFormat.Interfaces;

namespace BB84.FileFormat.Services;

/// <summary>
/// The decoder class.
/// </summary>
internal sealed class Decoder : IDecoder
{
	public File Decode(string filePath)
	{
		using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read);
		return Decode(stream);
	}

	public File Decode(FileStream stream)
	{
		using BinaryReader reader = new(stream);
		return Decode(reader);
	}

	public File Decode(byte[] data)
	{
		using MemoryStream stream = new(data);
		return Decode(stream);
	}

	public File Decode(MemoryStream stream)
	{
		using BinaryReader reader = new(stream);
		return Decode(reader);
	}

	private File Decode(BinaryReader reader)
	{
		try
		{
			if (reader.ReadUInt32() != File.Magic)
				throw new InvalidDataException("File does not have the correct format!");

			DateTime timeStamp = new((long)reader.ReadUInt64(), DateTimeKind.Utc);
			Purpose purpose = (Purpose)reader.ReadUInt32();
			uint dataLength = reader.ReadUInt32();
			byte[] data = reader.ReadBytes((int)dataLength);

			File file = new(timeStamp, new(purpose, dataLength), data);

			return file;
		}
		catch (Exception ex)
		{
			throw new DecoderException("Decoding error occurred!", ex);
		}
	}
}
