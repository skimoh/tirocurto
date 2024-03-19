using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CodeBehind.TiroCurto.RoboWeb
{
    public class Engine
    {
        private IWebDriver _driver;
        public Engine()
        {
            _driver = new ChromeDriver();
        }

        public void Abrir()
        {
            //acessando o site
            _driver.Navigate().GoToUrl("https://www.popsistemas.com.br/");

            //acionando o botao
            _driver.FindElement(By.XPath("//*[@id=\'navbarResponsive\']/ul/li[4]/a")).Click();

            var texto = _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/p[1]/a")).Text;

            Console.Write($"Telefone de contato {texto}");

            //preenchendo formulario
            //_driver.FindElement(By.XPath("")).SendKeys("Fulano");


            //TODO: captcha / teclado virtual / tempo de carregamento

            //submetendo
            //_driver.FindElement(By.XPath("")).Submit();

            //_driver.Quit();
        }
    }
}
