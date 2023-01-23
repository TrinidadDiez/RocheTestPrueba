using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;
public class SuiteTests : IDisposable {
  public IWebDriver driver {get; private set;}
  public IDictionary<String, Object> vars {get; private set;}
  public IJavaScriptExecutor js {get; private set;}
  public SuiteTests()
  {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<String, Object>();
  }
  public void Dispose()
  {
    driver.Quit();
  }
  public string waitForWindow(int timeout) {
    try {
      Thread.Sleep(timeout);
    } catch(Exception e) {
      Console.WriteLine("{0} Exception caught.", e);
    }
    var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
    var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
    if (whNow.Count > whThen.Count) {
      return whNow.Except(whThen).First().ToString();
    } else {
      return whNow.First().ToString();
    }
  }
  [Fact]
  public void Addevent() {
    driver.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin/signinchooser?passive=1209600&continue=https%3A%2F%2Faccounts.google.com%2F&followup=https%3A%2F%2Faccounts.google.com%2F&ifkv=AWnogHfKdRlb5aaQWOYruL5291AZkWq_CIP7nYafRCvG9Um_dng1YYL_zbIJVjMKw-lsLjCQF81RWQ&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
    driver.Manage().Window.Size = new System.Drawing.Size(1534, 832);
    driver.FindElement(By.CssSelector(".JDAKTe:nth-child(2) .BHzsHc")).Click();
    driver.FindElement(By.Id("identifierId")).Click();
    driver.FindElement(By.Id("identifierId")).SendKeys("myemail@gmail.com");
    driver.FindElement(By.CssSelector(".VfPpkd-LgbsSe-OWXEXe-k8QpJ > .VfPpkd-vQzf8d")).Click();
    {
      var element = driver.FindElement(By.CssSelector("#forgotPassword .VfPpkd-RLmnJb"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Perform();
    }
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("1234");
    driver.FindElement(By.CssSelector(".VfPpkd-LgbsSe-OWXEXe-k8QpJ > .VfPpkd-vQzf8d")).Click();
    driver.FindElement(By.CssSelector(".gb_g")).Click();
    {
      var element = driver.FindElement(By.CssSelector("#gbwa .gb_e"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Perform();
    }
    {
      var element = driver.FindElement(By.tagName("body"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element, 0, 0).Perform();
    }
    driver.FindElement(By.CssSelector(".gb_Ze")).Click();
    driver.SwitchTo().Frame(1);
    vars["WindowHandles"] = driver.WindowHandles;
    driver.FindElement(By.CssSelector(".u4RcUd > .j1ei8c:nth-child(8) .MrEfLc")).Click();
    vars["win3741"] = waitForWindow(2000);
    vars["root"] = driver.CurrentWindowHandle;
    driver.SwitchTo().Window(vars["win3741"].ToString());
    driver.FindElement(By.CssSelector(".QIadxc:nth-child(3) .t8qpF:nth-child(4)")).Click();
    driver.FindElement(By.CssSelector(".rFrNMe:nth-child(2) .Xb9hP:nth-child(1) > .whsOnd")).SendKeys("Test Event 1");
    driver.FindElement(By.CssSelector(".pEVtpe > .VfPpkd-vQzf8d")).Click();
    driver.FindElement(By.CssSelector(".QIadxc:nth-child(3) .t8qpF:nth-child(4)")).Click();
    {
      var element = driver.FindElement(By.CssSelector(".XsU8xf"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Perform();
    }
    driver.FindElement(By.CssSelector(".XsU8xf")).Click();
    Assert.Equal(driver.FindElement(By.CssSelector(".eADW5d:nth-child(4) .yzifAd")).Text, "Test Event 1");
    {
      var element = driver.FindElement(By.CssSelector(".d6McF .VfPpkd-Bz112c-LgbsSe"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Perform();
    }
    {
      var element = driver.FindElement(By.tagName("body"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element, 0, 0).Perform();
    }
    driver.FindElement(By.CssSelector(".gb_1d")).Click();
    {
      var element = driver.FindElement(By.CssSelector(".gb_Za"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Perform();
    }
    {
      var element = driver.FindElement(By.tagName("body"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element, 0, 0).Perform();
    }
    driver.FindElement(By.CssSelector(".gb_g")).Click();
    driver.SwitchTo().Frame(6);
    driver.FindElement(By.LinkText("Cerrar sesión")).Click();
    driver.Close();
    driver.SwitchTo().Window(vars["root"].ToString());
    driver.Close();
  }
}
