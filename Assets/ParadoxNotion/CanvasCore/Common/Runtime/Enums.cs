namespace ParadoxNotion
{

    ///<summary> Enumeration for comparisons</summary>
    public enum CompareMethod
    {
        EqualTo,//等于
        GreaterThan,//大于
        LessThan,//小于
        GreaterOrEqualTo,//大于等于
        LessOrEqualTo//小于等于
    }

    ///<summary> Enumeration for Operations (Add, Subtract, Equality etc)</summary>
    public enum OperationMethod
    {
        Set,//设置
        Add,//加
        Subtract,//减
        Multiply,//乘
        Divide//除
    }

    ///<summary> Enumeration for mouse button keys</summary>
	public enum ButtonKeys
    {
        Left = 0,
        Right = 1,
        Middle = 2
    }

    ///<summary> Enumeration for press types for inputs</summary>
	public enum PressTypes
    {
        Down,
        Up,
        Pressed
    }

    ///<summary> Enumeration for mouse press</summary>
	public enum MouseClickEvent
    {
        MouseDown = 0,
        MouseUp = 1
    }

    ///<summary> Enumeration for trigger unity events</summary>
	public enum TriggerTypes
    {
        TriggerEnter = 0,
        TriggerExit = 1,
        TriggerStay = 2
    }

    ///<summary> Enumeration for collision unity events</summary>
	public enum CollisionTypes
    {
        CollisionEnter = 0,
        CollisionExit = 1,
        CollisionStay = 2
    }

    ///<summary> Enumeration for mouse unity events</summary>
	public enum MouseInteractionTypes
    {
        MouseEnter = 0,
        MouseExit = 1,
        MouseOver = 2
    }

    ///<summary> Enumeration for boolean status result</summary>
	public enum CompactStatus
    {
        Failure = 0,
        Success = 1
    }

    ///<summary> Enumeration for Animation playing direction</summary>
    public enum PlayDirections
    {
        Forward,
        Backward,
        Toggle
    }

    ///<summary> Enumeration for planar direction</summary>
    public enum PlanarDirection
    {
        Horizontal,
        Vertical,
        Auto
    }

    ///<summary> Enumeration Alignment 2x2</summary>
    public enum Alignment2x2
    {
        Default,
        Left,
        Right,
        Top,
        Bottom
    }

    ///<summary> Enumeration Alignment 3x3</summary>
    public enum Alignment3x3
    {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }
    public enum HumanState
    {
        Idle = 0,
        Walk = 1,
        Run = 2
    }
}