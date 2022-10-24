using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStepsWithPlaywright
{
    public class Teste
    {
        [Test]
        public async Task Test1()
        {
            using var p = await Playwright.CreateAsync();
            //Browser
            //Por padrão, o Playwright roda o Browser em modo Headless, mudamos para false para ver o teste rodando no navegador
            await using var browser = await p.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            //Page
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://www.eaapp.somee.com");
            await page.ClickAsync("text=Login");
            //Esse método tira um print do momento que o teste é realizado
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "EAApp.jpg"
            });
            //Pega o campo pelo css select e preenche ele
            await page.FillAsync("#UserName", "admin");
            await page.FillAsync("#Password", "password");
            //Clica no botão que possui esse texto
            await page.ClickAsync("text=Log in");
            //Retorna se o determinado texto está visível ou não na tela
            var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
            Assert.IsTrue(isExist);
        }
    }
}
