

namespace UtilityBot.Services
{
    public interface ITextHandler
    {
        //Task Download(string fileId, CancellationToken ct);
        string Process(string param, string code);
    }
}
