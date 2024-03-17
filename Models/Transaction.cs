namespace Omegahash.Models
{
    public struct Transaction
    {
        public string TransactionHash { get; set; }
        public string Status { get; set; }
        public uint Block { get; set; }
        public uint Timestamp { get; set; }
        public Wallet From {  get; set; }
        public Wallet To { get; set; }
        public double Value { get; set; }
        public double TransactionFee { get; set; }
        public double GasPrice { get; set; }
    }
}
