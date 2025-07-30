# Day 06 – Selenium Automation
**Goal:Set up Selenium WebDriver in C# with NUnit for web automation. Build and run both basic and advanced UI interaction tests.**
**Tasks:**  
- [x] Setup Selenium WebDriver in C#
- [x] Add NUnit test framework
- [x] Create basic browser automation examples
- [x] Add advanced examples: date picker, file upload, scrolling, screenshots, click using JS, and fluent waits
- [x] Created Page Object for Login
- [x] Test automation using Page Objects
- [x] Configuration ready for credential-driven testing
- [x] Added ExtentReports for test result visualization
- [x] Integrated NUnit + Selenium + Reports
- [x] Take screenshot on test failure
- [x] Run tests in parallel using NUnit
- [x] Upload ExtentReports to GitHub CI
- [x] Page Object Model (POM)
- [x] Retry failed tests
- [x] Screenshot on failure
- [x] HTML Report using ExtentReports

## Summary of Learning & Cheat sheet 
- Selenium automates browser interaction using C#
- You can simulate user actions, upload files, pick dates, take screenshots, and handle waits
- FluentWait gives more flexibility over WebDriverWait by allowing polling and ignoring exceptions
- POM separates element locators from logic
- Test classes should be readable and minimal
- Configuration abstraction allows test reuse
- Uses NUnit Retry to handle flaky tests
- Automatically generates screenshot and report on failure

### Install NuGet Packages
```bash
dotnet add package AventStack.ExtentReports
dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
dotnet add package Selenium.Support
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

## Selenium Notes
The following content is referenced from Automate The Planet – Selenium Cheat Sheet
⚠️ Disclaimer: This content is reproduced for educational/reference purposes. All rights belong to the original author.

### Initialize
```csharp
// NuGet:Selenium.WebDriver.ChromeDriver
using OpenQA.Selenium.Chrome;
IWebDriver driver = new ChromeDriver
// NuGet: Selenium.Mozilla.Firefox.Webdriver
using OpenQA.Selenium.Firefox;
IWebDriver driver = new FirefoxDriver
// NuGet: Selenium.WebDriver.PhantomJS
using OpenQA.Selenium.PhantomJS;
IWebDriver driver = new PhantomJSDriver
// NuGet: Selenium.WebDriver.IEDriver
using OpenQA.Selenium.IE;
IWebDriver driver = new InternetExplorerDriver
// NuGet: Selenium.WebDriver.Edge Driver
using OpenQA.Selenium.Edge;
IWebDriver driver = new EdgeDriver
```
### Locators
```csharp
// Single element locators
this.driver.FindElement(By.ClassName("className"));
this.driver.FindElement(By.CssSelector("css"));
this.driver.FindElement(By.Id("id"));
this.driver.FindElement(By.LinkText("text"));
this.driver.FindElement(By.Name("name"));
this.driver.FindElement(By.PartialLinkText("pText"));
this.driver.FindElement(By.TagName("input"));
this.driver.FindElement(By.XPath("//*[ @id='editor']"));

// Find multiple elements
IReadOnlyCollection<IWebElement> anchors = this.driver.FindElements(By.TagName("a"));

// Search for an element inside another
var div = this.driver.FindElement(By.TagName("div"));
div.FindElement(By.TagName("a"));
```

### Basic Browser Options
```csharp
// Navigate to a page
this.driver.Navigate().GoToUrl(@"http://google.com");

// Get the title of the page
string title = this.driver.Title;

// Get the current URL
string url = this.driver.Url;

// Get the current page HTML source
string html = this.driver.PageSource;

```

### Advanced Browser Operations
```csharp
// Handle JavaScript pop-ups
IAlert a = driver.SwitchTo().Alert();
a.Accept();
a.Dismiss();

// Switch between browser windows or tabs
ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
string firstTab = windowHandles.First();
string lastTab = windowHandles.Last();
driver.SwitchTo().Window(lastTab);

// Navigation history
this.driver.Navigate().Back();
this.driver.Navigate().Refresh();
this.driver.Navigate().Forward();

// Focus an element
// Option 1
link.SendKeys(string.Empty);

// Option 2
((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].focus();", link);

// Maximize window
this.driver.Manage().Window.Maximize();

// Add a new cookie
Cookie cookie = new OpenQA.Selenium.Cookie("key", "value");
this.driver.Manage().Cookies.AddCookie(cookie);

// Get all cookies
var cookies = this.driver.Manage().Cookies.AllCookies;

// Delete a cookie by name
this.driver.Manage().Cookies.DeleteCookieNamed("CookieName");

// Delete all cookies
this.driver.Manage().Cookies.DeleteAllCookies();

// Taking a full-screen screenshot
Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
screenshot.SaveAsFile(@"pathToImage", ImageFormat.Png);

// Wait until a page is fully loaded via JavaScript
WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
wait.Until((x) =>
{
    return ((IJavaScriptExecutor)this.driver).ExecuteScript("return document.readyState").Equals("complete");
});

// Switch to frames
this.driver.SwitchTo().Frame(1);
this.driver.SwitchTo().Frame("frameName");
this.driver.SwitchTo().Frame(this.driver.FindElement(By.Id("id")));

// Switch to the default document
this.driver.SwitchTo().DefaultContent();

```
### Basic Elements Operations
```csharp
// Basic Elements Operations

IWebElement element = driver.FindElement(By.Id("id"));
element.Click();
element.SendKeys("someText");
element.Clear();
element.Submit();

string innerText = element.Text;
bool isEnabled = element.Enabled;
bool isDisplayed = element.Displayed;
bool isSelected = element.Selected;

IWebElement dropdown = driver.FindElement(By.Id("id"));
SelectElement select = new SelectElement(dropdown);

// Select operations
select.SelectByIndex(1);
select.SelectByText("Ford");
select.SelectByValue("Ford");
select.DeselectAll();
select.DeselectByIndex(1);
select.DeselectByText("Ford");
select.DeselectByValue("Ford");

// Selected options
IWebElement selectedOption = select.SelectedOption;
IList<IWebElement> allSelected = select.AllSelectedOptions;
bool isMultipleSelect = select.IsMultiple;

```
### Advanced Element Operations
```csharp
// Drag and Drop
IWebElement element = driver.FindElement(By.XPath("//*[ @id='project']/p[1]/div/div[2]"));
Actions move = new Actions(driver);
move.DragAndDropToOffset(element, 30, 0).Perform();

// How to check if an element is visible
Assert.IsTrue(driver.FindElement(By.XPath("//*[ @id='tve_editor']/div")).Displayed);

// Upload a file
IWebElement fileElement = driver.FindElement(By.Id("RadUploadfile0"));
string filePath = @"D:\WebDriver.Series.Tests\WebDriver.xml";
fileElement.SendKeys(filePath);

// Scroll focus to control
IWebElement link = driver.FindElement(By.PartialLinkText("Previous post"));
string js = string.Format("window.scrollTo(0, {0});", link.Location.Y);
((IJavaScriptExecutor)driver).ExecuteScript(js);
link.Click();

// Taking an element screenshot
IWebElement targetElement = driver.FindElement(By.XPath("//*[ @id='tve_editor']/div"));
var cropArea = new Rectangle(targetElement.Location, targetElement.Size);
var bmpScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
var bmp = bmpScreen.Clone(cropArea, bmpScreen.PixelFormat);
bmp.Save("fileName.png");

// Focus on a control
driver.FindElement(By.PartialLinkText("Previous post")).Click();

// Wait until element is present
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(
    By.XPath("//*[ @id='tve_editor']/div[2]/div[2]/div")));

```
### Advanced Browser Configurations
```csharp
// Use a specific Firefox profile
FirefoxProfileManager profileManager = new FirefoxProfileManager();
FirefoxProfile profile = profileManager.GetProfile("HARDDISKUSER");
IWebDriver driver = new FirefoxDriver(profile);

// Set a HTTP proxy Firefox
FirefoxProfile firefoxProfile = new FirefoxProfile();
firefoxProfile.SetPreference("network.proxy.type", 1);
firefoxProfile.SetPreference("network.proxy.http", "myproxy.com");
firefoxProfile.SetPreference("network.proxy.http_port", 3239);
driver = new FirefoxDriver(firefoxProfile);

// Set a HTTP proxy Chrome
Proxy proxy = new Proxy();
proxy.Kind = ProxyKind.Manual;
proxy.IsAutoDetect = false;
proxy.HttpProxy = "127.0.0.1:3239";

ChromeOptions options = new ChromeOptions();
options.Proxy = proxy;
options.AddArgument("ignore-certificate-errors");
driver = new ChromeDriver(options);

// Accept all certificates Firefox
DesiredCapabilities capability = DesiredCapabilities.Firefox();
capability.SetCapability(CapabilityType.AcceptInsecureCertificates, true);
driver = new RemoteWebDriver(capability);

// Accept all certificates Chrome
capability = DesiredCapabilities.Chrome();
capability.SetCapability(CapabilityType.AcceptSslCertificates, true);
driver = new RemoteWebDriver(capability);

// Set Chrome options
ChromeOptions co = new ChromeOptions();
DesiredCapabilities dc = DesiredCapabilities.Chrome();
dc.SetCapability(ChromeOptions.Capability, co);
driver = new RemoteWebDriver(dc);

// Turn off the JavaScript Firefox
profileManager = new FirefoxProfileManager();
profile = profileManager.GetProfile("HARDDISKUSER");
profile.SetPreference("javascript.enabled", false);
driver = new FirefoxDriver(profile);

// Set driver to wait page load timeout
driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

// Use a new Firefox profile
FirefoxProfile newProfile = new FirefoxProfile();
newProfile.AddExtension(@"C:\extensionLocation\extension.xpi");
driver = new FirefoxDriver(newProfile);

// Start Chrome with unpacked extension
ChromeOptions extOptions = new ChromeOptions();
DesiredCapabilities dcaps = DesiredCapabilities.Chrome();
extOptions.AddArguments("load-extension=C:\\Path\\To\\Unpacked\\Extension");
dcaps.SetCapability(ChromeOptions.Capability, extOptions);
driver = new ChromeDriver(dcaps);

// Start Chrome with extension crx
ChromeOptions extOptions2 = new ChromeOptions();
extOptions2.AddExtension(@"C:\Path\To\Extension\extension.crx");
dcaps = DesiredCapabilities.Chrome();
dcaps.SetCapability(ChromeOptions.Capability, extOptions2);
driver = new ChromeDriver(dcaps);

// Change the default files’ save location
FirefoxProfile downloadProfile = new FirefoxProfile();
downloadProfile.SetPreference("browser.download.folderList", 2);
downloadProfile.SetPreference("browser.download.dir", @"D:\downloadFolderPath");
downloadProfile.SetPreference("browser.download.manager.alertOnEXEOpen", false);
downloadProfile.SetPreference(
    "browser.helperApps.neverAsk.saveToDisk",
    "application/pdf, application/vnd.ms-excel, application/xls, text/csv, " +
    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, " +
    "application/msword, application/octet-stream"
);
driver = new FirefoxDriver(downloadProfile);

```

## Selenium Web Driver Locator
### XPath Locator
| XPath Locator                             | Explanation                                                   |
|------------------------------------------|---------------------------------------------------------------|
| //img                                     | Image element                                                 |
| //img[@id='myid']                         | Image element with @id='myid'                                 |
| //img[@id!='myid']                        | Image elements with @id not equal to 'myid'                   |
| //img[@name]                              | Image elements that have name attribute                       |
| //*[contains(@id, 'id')]                  | Element with @id containing 'id'                              |
| //*[starts-with(@id, 'id')]               | Element with @id starting with 'id'                           |
| //*[ends-with(@id, 'id')]                 | Element with @id ending with 'id'                             |
| //*[matches(@id, 'r')]                    | Element with @id matching regex 'r'                           |
| //*[@name='myName']                       | Element with @name='myName'                                   |
| //*[@id='X' or @name='X']                 | Element with @id='X' or @name='X'                             |
| //*[@name='N'][@value='V']                | Element with @name='N' and @value='V'                         |
| //*[@name='N' and @value='V']             | Element with @name='N' and @value='V'                         |
| //*[@name='N' and not(@value='V')]        | Element with @name='N' not @value='V'                         |
| //input[@type='submit']                   | Input of type submit                                          |
| //section[h1][@id='H1']                   | Returns `<section>` if it has an `<h1>` descendant with @id='H1' |
| //table[count(tr) > 1]                    | Return table with more than 1 row                             |
| //a[text()='t']                           | Element containing text 't' exactly                           |
| //a[contains(text(), 'Log Out')]         | Anchor with inner text containing 'Log Out'                   |
| //a[not(contains(text(), 'Log Out'))]     | Anchor with inner text not containing 'Log Out'               |
| //a[@href='url']                          | Anchor with target link 'url'                                 |
| //ul//img[1]                              | First child of element `<ul>` that is `<img>`                 |
| //ul/li[1]                                | First child of `<ul>`                                         |
| //img[last()]                             | Last child of element `<img>`                                 |
| //ul/li[last()]                           | Last `<li>` child                                             |
| //ul/li[2]                                 | Second `<li>` child                                           |
| //input/following-sibling::a              | `<a>` following some sibling `<input>`                        |
| //a/following-sibling::input              | `<input>` element immediately following `<a>`                 |
| //input/preceding-sibling::p              | `<p>` sibling element immediately preceding `<input>`         |
| //img[@id='id']/parent::*                 | The parent of image with id                                   |
| //td[@id='Test']/ancestor::tr             | Cell row by row and column                                    |
| //td[preceding-sibling::td='t']           | Cell immediately following cell containing 't'                |
| //input[preceding-sibling::label='t']     | Checkbox or radio button whose label text is 't'              |
| //input[@checked]                         | `<input>` element that is checked                             |
| //a[not(@disabled)]                       | All `<a>` elements that are not disabled                      |
| //a[@disabled]                            | All `<a>` elements that are disabled                          |
| //a[not(@disabled)]                       | All `<a>` elements that are not disabled                      |
| //ul[*]                                   | `<ul>` that has children                                      |
| //ul[li]                                  | `<ul>` that has `<li>` children                               |
| //a[@price > 2.50]                        | `<a>` with price > 2.5                                        |

### CSS Locators
| CSS Locator                                       | Explanation                                                                 |
|--------------------------------------------------|-----------------------------------------------------------------------------|
| ul#myId                                          | `<ul>` element with `@id='myId'`                                           |
| *[id=myUniqueId]                                 | Any element with `@id='myUniqueId'`                                        |
| ul#myForm                                        | `<ul>` element with `@id='myForm'`                                         |
| .myForm.front                                     | Any element with classes `myForm` and `front`                              |
| ul#myUniqueId > li                               | Direct child element                                                       |
| ul#myUniqueId li                                 | Sub-child element                                                          |
| [name^="autoName"][style*="style-name"]          | `@name` starting with `autoName` and `@style` containing `style-name`      |
| ul[id="myId"]                                    | `<ul>` element with `@id='myId'`                                           |
| [name="N"][value="V"]                            | Element with name N and value V                                            |
| [id^="my"]                                       | All elements with an attribute starting with `my`                         |
| [id$="Id"]                                       | All elements with an attribute ending with `Id`                           |
| [id*="unique"]                                   | All elements with an attribute containing `unique`                        |
| ul#myUniqueId li:first-child                     | First child element                                                        |
| ul#myUniqueId li:nth-of-type(1)                  | First child element                                                        |
| ul#myUniqueId li:last-child                      | Last child element                                                         |
| ul#myUniqueId li:nth-of-type(3)                  | Third child element                                                        |
| div > p                                          | All `<p>` that are a direct descendant of a `<div>`                        |
| div + p                                          | All `<p>` that are the next sibling of a `<div>` (placed directly after)   |
| div ~ p                                          | All `<p>` that follow, and are siblings of `<div>`                         |
| a:link                                           | All unvisited links                                                        |
| a:visited                                        | All visited links                                                          |
| a:hover                                          | All links on mouse hover                                                   |
| input:disabled                                   | Every disabled `<input>` element                                           |
| input:enabled                                    | Every enabled `<input>` element                                            |
| input:focus                                      | The `<input>` element which has focus                                      |
| input:read-only                                  | `<input>` elements with `readonly` attribute specified                     |
| input:required                                   | `<input>` elements with `required` attribute                              |
| input:checked                                    | Radio or checkbox input that is checked                                   |
| ul.myForm.front + ul                             | Next `<ul>` element immediately following `.myForm.front`                  |
| a:contains('Log Out')                            | Anchor with inner text containing 'Log Out'                                |
| table tr:nth-child(3) td:nth-child(2)            | Row 3, Column 2 cell (i.e., row by row, column by column)                  |
| tr td:first-child + td                           | `<td>` immediately following the first `<td>`                              |
| p[lang|="language"]                              | All `<p>` elements with a `lang` attribute containing `language`           |

### Page Object Model - FindsBy Attributes
```csharp
[FindsBy(How = How.Id, Using = "userName")]
[FindsBy(How = How.ClassName, Using = "panel other")]
[FindsBy(How = How.CssSelector, Using = "#userName")]
[FindsBy(How = How.LinkText, Using = "Automate Planet")]
[FindsBy(How = How.Name, Using = "webDriverCheatSheet")]
[FindsBy(How = How.PartialLinkText, Using = "Automate")]
[FindsBy(How = How.TagName, Using = "a")]
[FindsBy(How = How.XPath, Using = "//*[@id='pan']/div")]
private IWebElement _myElement;

```

### Default FindElement
```csharp
_driver.FindElement(By.Id("userName"));
_driver.FindElement(By.ClassName("panel other"));
_driver.FindElement(By.CssSelector("#userName"));
_driver.FindElement(By.LinkText("Automate The Planet"));
_driver.FindElement(By.Name("webDriverCheatSheet"));
_driver.FindElement(By.PartialLinkText("Automate"));
_driver.FindElement(By.TagName("a"));
_driver.FindElement(By.XPath("//*[ @id='panel']/div/h1"));

```