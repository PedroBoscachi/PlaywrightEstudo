using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStepsWithPlaywright
{
    //Ao herdar de PageTest, não é necessário fazer as configurações iniciais de browser e do Playwright
    public class NUnitPlaywright : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("http://www.eeapp.somee.com");
        }

        [Test]
        public async Task Test1()
        {
            //Ao usar um Locator, vc pode armazenar o item a ser testado e testa-lo somente quando desejar
            var lnkLogin = Page.Locator("text=Login");
            await lnkLogin.ClickAsync();

            await Page.ClickAsync("text=Login");
            //Pega o campo pelo css select e preenche ele
            await Page.FillAsync("#UserName", "admin");
            await Page.FillAsync("#Password", "password");

            //Se existir um input com o texto de Log in, seleciona ele
            var btnLogin = Page.Locator("input", new PageLocatorOptions { HasTextString = "Log in" });
            await btnLogin.ClickAsync();
            //Clica no botão que possui esse texto
            await Page.ClickAsync("text=Log in");
            await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
        }
    }
}
