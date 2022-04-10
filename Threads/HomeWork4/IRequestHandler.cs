namespace HomeWork4;

/// <summary>
///Provides the ability to process a request.
/// </summary>
public interface IRequestHandler
{
    /// <summary>
    /// Process the request.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="arguments">Request Arguments</param>
    /// <returns>The result of the request.</returns>
    string HandleRequest(string message, string[] arguments);
}