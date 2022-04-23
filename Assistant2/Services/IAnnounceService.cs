namespace Assistant2.Services;

public interface IAnnounceService
{
    public void SendDefault(string text);

    public void SendMagic(string text,string title,int sound);
}