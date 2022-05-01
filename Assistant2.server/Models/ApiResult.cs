namespace Assistant2.Models;

public class ApiResult
{
    public int Code { get; set; }
    public string? Msg { get; set; }
    public object? Data { get; set; }

    public static ApiResult Success(object? data)
    {
        return new ApiResult
        {
            Code = 200,
            Data = data
        };
    }

    public static ApiResult Failed(int code,string msg)
    {
        return new ApiResult
        { 
            Code = code,Msg = msg
        };
    }
}