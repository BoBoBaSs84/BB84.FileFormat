namespace BB84.FileFormat.Exceptions;

/// <summary>
/// Initializes a new instance of the <see cref="DecoderException"/> class with a specified
/// error message and a reference to the inner exception that is the cause of this exception.
/// </summary>
/// <inheritdoc/>
public sealed class DecoderException(string message, Exception innerException) : Exception(message, innerException)
{ }
