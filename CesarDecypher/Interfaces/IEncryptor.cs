namespace CypherLogic.Interfaces
{
    public interface IEncryptor
    {
        string AlghorithmName { get; set; }
        string Encrypt(string message);
        string Decrypt(string message);
    }
}
