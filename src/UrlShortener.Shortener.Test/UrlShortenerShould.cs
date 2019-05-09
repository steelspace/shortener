using Moq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UrlShortener.Abstractions;
using Xunit;

namespace UrlShortener.Shortener.Test
{
    public class UrlShortenerShould
    {
        const string USER_ID = "user-id-1";

        private readonly Mock<IDataProvider> _dataProviderMock = new Mock<IDataProvider>();
        
        private readonly Regex _shorUrlSlugFormat = new Regex("[a-z][0-9]");

        //[Theory]
        //[InlineData("https://gist.github.com/jasonyost/487023")]
        //[InlineData("https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/")]
        //[InlineData("https://www.idnes.cz/volby/evropsky-parlament/2019/popisil-top-09-slavia-slogan-volby-evorpsky-parlament-spolu-jsme-silnejsi.A190509_143423_volby-ep2019_maka")]
        //public async Task ReturnShortUrlSlug(string url)
        //{
        //    _dataProviderMock.Setup(d => d.AddUrl(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
            
        //    var shortener = new Md5SShortProvider(_dataProviderMock.Object);

        //    string shortUrl = await shortener.GenerateUrl(url, USER_ID);

        //    Assert.NotEmpty(shortUrl);
        //    Assert.Matches(_shorUrlSlugFormat, shortUrl);
        //}

        //[Theory]
        //[InlineData("https://gist.github.com/jasonyost/487023")]
        //public async Task ReturnNull_IfThereIsACollision(string url)
        //{
        //    _dataProviderMock.Setup(d => d.AddUrl(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(false);

        //    var shortener = new Md5SShortProvider(_dataProviderMock.Object);

        //    string shortUrl = await shortener.GenerateUrl(url, USER_ID);

        //    Assert.Null(shortUrl);
        //}
    }
}
