
public class Indicator
{
    private static int minValue = 0;
    private bool isVital;
    private float _valueCoeff;
    private int _value, _startValue, _maxValue;
    private string _dimension;
    public Indicator(int startValue, int maxValue, string dimension, bool isVital)
    {
        _value = startValue;
        _dimension = dimension;
        _startValue = startValue;
        _maxValue = maxValue;

        ValueCoeff = 1f;
        IsVital = isVital;
        
    }

    public int Value
    {
        get => _value;
        set
        {
            int valueWithCoeff = (int)(value * ValueCoeff);

            if (valueWithCoeff >= MaxValue)
                _value = MaxValue;
            else if (valueWithCoeff <= minValue)
            {
                _value = minValue;

                if (isVital)
                {
                    Game.GameOver();
                    return;
                }
            }
            else
                _value = valueWithCoeff;
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
    public bool IsVital { get => isVital; private set => isVital = value; }

    public void InitializeStartValue() => Value = StartValue;
}
