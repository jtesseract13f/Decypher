namespace CypherLogic.Interfaces
{
    public interface ICypher
    {
        string AlghorithmName { get; set; }
        string Encrypt(string message);
        string Decrypt(string message);
    }
}
