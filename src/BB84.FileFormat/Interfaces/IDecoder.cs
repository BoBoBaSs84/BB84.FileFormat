namespace BB84.FileFormat.Interfaces;

public interface IDecoder
{
	File Decode(string filePath);
	File Decode(FileStream stream);
	File Decode(byte[] data);
	File Decode(MemoryStream stream);
}
