
public class Indicator
{
    private static int minValue = 0;
    private int _value, _startValue, _maxValue;
    private string _dimension;
    public Indicator(int startValue, int maxValue, string dimension)
    {
        _value = startValue;
        _dimension = dimension;
        _startValue = startValue;
        _maxValue = maxValue;
    }

    public int Value
    {
        get => _value;
        set
        {
            if (value + _value <= _maxValue || value + _value >= minValue)
            _value = value;
        }
    }
    
    public int StartValue
    {
        get => _startValue;
        private set { }
    } 
    public string Dimension
    {
        get => _dimension;
        private set { }
    }
    
    public int MaxValue
    {
        get => _maxValue;
        private set { }
    }

    public void InitializeStartValue() => Value = StartValue;
}
