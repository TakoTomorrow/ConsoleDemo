using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Autofac;
using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
using ConsoleDemo.Service.Interface;
using ConsoleDemo.Service;
using NLog;
using ConsoleDemo.TO;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;

// 使用NLog紀錄程式啟動
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Trace("Init main");

try
{
    IExampleService service = new AsyncTest();

    // 服務執行
    service.DemoTask();

    Console.Read();
}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");    
}
finally
{
    // 關閉NLog
    NLog.LogManager.Shutdown();
}