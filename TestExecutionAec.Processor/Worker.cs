using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestExecutionAec.Processor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        //private IWebDriver _driver;
        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");

            //_driver = new ChromeDriver(
            //    _configuration["CaminhoChromeDriver"],
            //    chromeOptions);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                
                //_driver.Navigate().GoToUrl("https://www.aec.com.br/");

                //// Acessando menu de busca.
                //_element = GetWebElement("//*[@id=\"header\"]/div[2]/div/div/div/div/ul[2]/li[2]/a");
                //_element.Click();

                //await Task.Delay(2000, stoppingToken);

                ////Inserindo valor campo texto
                //_element = GetWebElement("//*[@id=\"form\"]/input");
                //_element.SendKeys("Automação");


                await Task.Delay(1000, stoppingToken);


            }
        }


        //private IWebElement GetWebElement(string xpath)
        //{
        //    return _driver.FindElement(By.XPath($"{xpath}"));
        //}
    }
}