namespace CypherLogic.Interfaces
{
    public interface IEncryptor
    {
        public string AlghorithmName { get; set; }
        public string Encrypt(string message);
        public string Decrypt(string message);
    }
}
