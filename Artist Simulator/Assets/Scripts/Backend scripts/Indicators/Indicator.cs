
public class Indicator
{
    private static int minValue = 0;
    private float _valueCoeff;
    private int _value, _startValue, _maxValue;
    private string _dimension;
    public Indicator(int startValue, int maxValue, string dimension)
    {
        _value = startValue;
        _dimension = dimension;
        _startValue = startValue;
        _maxValue = maxValue;

        ValueCoeff = 1f;
    }

    public int Value
    {
        get => _value;
        set
        {
            if(GameControls.IsCorrect(value))
            {
                int valueWithCoeff = (int)(value * ValueCoeff);
                if (valueWithCoeff + _value <= _maxValue || valueWithCoeff + _value >= minValue)
                    _value = valueWithCoeff;
            }
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

    public float ValueCoeff { get => _valueCoeff; set => _valueCoeff = value; }

    public void InitializeStartValue() => Value = StartValue;
}
