using BB84.FileFormat.Exceptions;

namespace BB84.FileFormat.Interfaces;

public interface IEncoder
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="file"></param>
	/// <returns></returns>
	/// <exception cref="EncoderException"></exception>
	byte[] Encode(File file);
}
