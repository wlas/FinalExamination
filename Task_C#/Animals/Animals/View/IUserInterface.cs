namespace Animals.View
{
    public interface IUserInterface
    {
        void Write(string str);
        void WriteLine(string str);
        string StringWrite(string str);
        DateTime DateTimeWrite(string str);
    }
}
