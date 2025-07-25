using System.Xml;


namespace TestAutomation.Tests.XMLTesting
{
    [TestFixture]
    public class XmlTest
    {
        [Test]
        public void XmlTextReaderTest()
        {
            var reader = new XmlTextReader(@"Tests/XMLTesting/books.xml");
            while(reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element && reader.Name == "Title")
                {
                    Console.WriteLine(reader.ReadElementContentAsString());
                }
            }

            reader.Close();
        }
    }
}
