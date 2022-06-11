using System.Threading.Tasks;
using Assistant2.Services.DDns;
using NUnit.Framework;

namespace TestProject1;

public class DDnsServiceTest
{
    [Test]
    public async Task GetIpTest()
    {
        var service = new DDnsService();
        var ip = await service.QueryIp();
        service.UpdateDnsRecord(ip);
        service.UpdateDnsRecord(ip);
    }
}