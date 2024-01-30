using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestExecutionAec.Domain.AggregatesModel;

namespace TestExecutionAec.Application.Commands;
public class ProcessarDadosAecCommandHandler : IRequestHandler<ProcessarDadosAecCommand, IActionResult>, IDisposable
{
    private readonly string _url = "https://www.aec.com.br/";

    private readonly IWebDriver _driver;
    private IWebElement _element;
    private IReadOnlyList<IWebElement> _elements;

    public ProcessarDadosAecCommandHandler()
    {
        var chromeOptions = new ChromeOptions();
        //chromeOptions.AddArgument("--headless");

        _driver = new ChromeDriver(chromeOptions);
    }

    public async Task<IActionResult> Handle(ProcessarDadosAecCommand request, CancellationToken cancellationToken)
    {
        _driver.Navigate().GoToUrl(_url);
        _driver.Manage().Window.Maximize();

        //_fluentWait.Timeout = TimeSpan.FromSeconds(10);
        await Task.Delay(2000, cancellationToken);

        // Acessando menu de busca.
        _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/div/div/ul[2]/li[2]/a")).Click();

        //Inserindo valor campo texto
        _element = _driver.FindElement(By.XPath($"//*[@id=\"form\"]/input"));
        await Task.Delay(1000, cancellationToken);

        _element.SendKeys("Automação");

        _element.Submit();

        // Extraindo informações dos cards
        _elements = _driver.FindElements(By.CssSelector("a.cardPost.mb-5"));
        var objeto = new List<object>();

        foreach (var item in _elements)
            objeto.Add(item.GetAttribute("innerText").Split("\n"));


        var resultados = new List<Card>();
        foreach (var item in objeto)
        {
            var resultado = new Card()
            {
                Titulo = ((string[])item)[1],
                Area = ((string[])item)[0],
                Autor = ((string[])item)[2].Split("por")[1].Split("em")[0].Trim(),
                DataPublicacao = ((string[])item)[2].Split("em")[1].Trim(),
                //Autor = Regex.Split(Regex.Split(((string[])item)[2], "por")[1], "em")[0].Trim(),
                //DataPublicacao = Regex.Split(((string[])item)[2], "em")[1].Trim(),
                Descricao = ((string[])item)[4],

            };
            resultados.Add(resultado);
        }

        await Task.Delay(10000, cancellationToken);

        return (IActionResult)Task.FromResult(resultados.FirstOrDefault());
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

