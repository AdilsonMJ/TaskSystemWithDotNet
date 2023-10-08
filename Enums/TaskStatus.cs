using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("Have to do")]
        TODO = 1,
        [Description("Working on it")]
        DOING = 2,
        [Description("Finish!")]
        DONE = 3
    }
}
