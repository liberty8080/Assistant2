namespace Assistant2.Models;

public class ApiResult
{
    public const int Ok = 200;
    public const int Error = 10000;
        
    public int Code { get; set; }
    public string? Msg { get; set; }
    public object? Data { get; set; }

    public static ApiResult Success(object? data)
    {
        return new ApiResult
        {
            Code = Ok,
            Data = data
        };
    }

    public static ApiResult None(string msg)
    {
        return new ApiResult
        {
            Code = Ok,
            Msg = msg
        };
    }

    public static ApiResult Failed(string msg)
    {
        return new ApiResult
        {
            Code = Error, Msg = msg
        };
    }
}