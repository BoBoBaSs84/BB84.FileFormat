namespace BB84.FileFormat;

public readonly struct File(DateTime timeStamp, Header header, byte[] data)
{
	/// <summary>
	/// The magic number containing the four character code value 'BB84'.
	/// </summary>
	public const uint Magic = ('B' << 0) | ('B' << 8) | ('8' << 16) | ('4' << 24);

	/// <summary>
	/// The timestamp of the file.
	/// </summary>
	public DateTime TimeStamp { get; } = timeStamp;

	/// <summary>
	/// The header of the file.
	/// </summary>
	public Header Header { get; } = header;

	/// <summary>
	/// The data of the file.
	/// </summary>
	public byte[] Data { get; } = data;
}

public readonly struct Header(Purpose purpose, uint dataLength)
{
	/// <summary>
	/// The purpose of the file.
	/// </summary>
	public Purpose Purpose { get; } = purpose;

	/// <summary>
	/// The data length of the file data.
	/// </summary>
	public uint DataLength { get; } = dataLength;
}

[Flags]
public enum Purpose : uint
{
	Storage = 1 << 0,
	Information = 1 << 1,
	Picture = 1 << 2,
	Audio = 1 << 3,
	Video = 1 << 4,
	Archive = 1 << 5
}
