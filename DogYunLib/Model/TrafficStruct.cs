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

        public static TrafficStruct operator +(TrafficStruct ts1, TrafficStruct ts2)
            => new TrafficStruct()
            {
                Date = ts1.Date + "+" + ts2.Date,
                OutputIn = ts1.OutputIn + ts2.OutputIn,
                OutputOut = ts1.OutputOut + ts2.OutputOut,
                InputIn = ts1.InputIn + ts2.InputIn,
                InputOut = ts1.InputOut + ts2.InputOut
            };

        public static TrafficStruct operator -(TrafficStruct ts1, TrafficStruct ts2)
            => new TrafficStruct()
            {
                Date = ts1.Date + "-" + ts2.Date,
                OutputIn = ts1.OutputIn - ts2.OutputIn,
                OutputOut = ts1.OutputOut - ts2.OutputOut,
                InputIn = ts1.InputIn - ts2.InputIn,
                InputOut = ts1.InputOut - ts2.InputOut
            };
    }
}
