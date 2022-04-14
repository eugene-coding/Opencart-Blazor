namespace Opencart.Data;

public struct FilterData
{
    private const byte DefaultLimit = 20;

    private uint _limit;

    public uint Start { get; set; }
    public uint Limit
    {
        get => _limit;
        init => _limit = value < 1 ? DefaultLimit : value;
    }
}
