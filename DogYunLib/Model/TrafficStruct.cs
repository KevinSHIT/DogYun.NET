namespace DogYun.Model
{
    public struct TrafficStruct
    {
        public string Date { get; internal set; }
        public long OutputIn { get; internal set; }
        public long OutputOut { get; internal set; }
        public long InputIn { get; internal set; }
        public long InputOut { get; internal set; }
        public long In { get => InputIn + OutputIn; }
        public long Out { get => InputOut + OutputOut; }
        public double EFR { get => 1.0 * Out / In; }
    }
}
